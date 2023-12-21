using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Net;
using System.Threading.Tasks;

namespace FoodMenuApi.Constraints
{
    public class CategoryRouteHandler : IRouter
    {
        private readonly IRouter _defaultRouter;
        private readonly IConfiguration _configuration;

        public CategoryRouteHandler(IRouter defaultRouter,IConfiguration configuration)
        {
            _defaultRouter = defaultRouter;
            _configuration = configuration;
        }

        public VirtualPathData GetVirtualPath(VirtualPathContext virtualPathContext)
        {
            return _defaultRouter.GetVirtualPath(virtualPathContext);
        }

        public async Task RouteAsync(RouteContext routeContext)
        {
            var categoryName = routeContext.RouteData.Values["categoryName"]?.ToString();
            if (!string.IsNullOrEmpty(categoryName) && !categoryName.All(char.IsLetter))
            {
                routeContext.Handler = async httpContext =>
                {
                    httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    string errorMessage = _configuration["ErrorMessages:InvalidCategoryName"];
                    await httpContext.Response.WriteAsync(errorMessage);
                };
                return;
            }

            await _defaultRouter.RouteAsync(routeContext);
        }
    }
}
