// using System.Collections.Generic;
// using System.Threading.Tasks;
// using FoodMenuApi.Data;
// using FoodMenuApi.Interfaces;
// using FoodMenuApi.Models;
// using Microsoft.EntityFrameworkCore;

// namespace FoodMenuApi.Services
// {
//     public class MenuService : IFoodMenuService
//     {
//         private readonly MenuAppDbContext _db;

//         public MenuService(MenuAppDbContext repository)
//         {
//             _db = repository;
//         }

//         public async Task<FoodItem> GetFoodItemAsync(int foodItemId)
//         {
//             return await _db.FoodItems.FindAsync(foodItemId);
//         }

//         public async Task<List<FoodItem>> GetAllFoodItemsAsync()
//         {
//             return await _db.FoodItems.ToListAsync();
//         }

//         public async Task<List<FoodItem>> GetFoodItemsByPriceAsync(decimal price)
//         {
//             return await _db.FoodItems
//                 .Where(p => p.Price <= price)
//                 .ToListAsync();
//         }



//         public async Task<List<FoodCategory>> GetFoodCategoriesAsync()
//         {
//             // Group food items by category
//             var categories = await _db.FoodItems
//                 .GroupBy(p => p.Category)
//                 .Select(g => new FoodCategory
//                 {
//                     Name = g.Key,
//                     Items = g.ToList()
//                 })
//                 .ToListAsync();

//             return categories;
//         }

//         public async Task<List<FoodItem>> GetFoodItemsByVeganAsync(bool isVegan)
//         {
//             return await _db.FoodItems
//                 .Where(p => p.IsVegan == isVegan)
//                 .ToListAsync();
//         }

//         public async Task<List<FoodItem>> GetFoodItemsByCaloriesAsync(float maxCalories)
//         {
//             return await _db.FoodItems
//                 .Where(p => p.Calories <= maxCalories)
//                 .ToListAsync();
//         }



//         public async Task AddFoodItemAsync(FoodItem foodItem)
//         {
//             await _db.FoodItems.AddAsync(foodItem);
//             await _db.SaveChangesAsync();
//         }


//         public async Task UpdateFoodItemAsync(FoodItem foodItem)
//         {
//             // Retrieve the existing food item from the database
//             var existingFoodItem = await _db.FoodItems.FindAsync(foodItem.Id);

//             // Update the properties of the existing food item with the new values
//             existingFoodItem.Name = foodItem.Name;
//             existingFoodItem.Price = foodItem.Price;
//             existingFoodItem.Category = foodItem.Category;
//             existingFoodItem.Description = foodItem.Description;

//             // Mark the existing food item as modified
//             _db.Entry(existingFoodItem).State = EntityState.Modified;

//             // Save the changes to the database
//             await _db.SaveChangesAsync();
//         }

//         public async Task DeleteFoodItemAsync(int foodItemId)
//         {
//             var foodItem = await _db.FoodItems.FindAsync(foodItemId);
//             if (foodItem != null)
//             {
//                 _db.FoodItems.Remove(foodItem);
//                 await _db.SaveChangesAsync();
//             }
//         }

//         public async Task<List<FoodItem>> GetFoodItemsByCategoryAsync(string categoryName)
//         {
//             return await _db.FoodItems
//                 .Where(p => p.Category == categoryName)
//                 .ToListAsync();
//         }



        
//     }
// }

using System.Collections.Generic;
using System.Threading.Tasks;
using FoodMenuApi.Data;
using FoodMenuApi.Interfaces;
using FoodMenuApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Microsoft.Extensions.Configuration;

namespace FoodMenuApi.Services
{
    public class MenuService : IFoodMenuService
    {
        private readonly MenuAppDbContext _menuAppDbContext;

        public MenuService(IConfiguration configuration)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MenuAppDbContext>()
                .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
                .Options;

            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required,
                new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted }))
            {
                _menuAppDbContext = new MenuAppDbContext(dbContextOptionsBuilder);

                transactionScope.Complete();
            }
        }

        public async Task<List<FoodCategory>> GetFoodCategoriesAsync()
        {
            // Group food items by category
            var categories = await _menuAppDbContext.FoodItems
                .GroupBy(foodItems => foodItems.category)
                .Select(foodCategories => new FoodCategory
                {
                    name = foodCategories.Key,
                    items = foodCategories.Where(foodItem => !foodItem.IsInGallery).ToList()
                })
                .ToListAsync();

            return categories;
        }
        public async Task<FoodItem> GetFoodItemAsync(int foodItemId)
        {
            return await _menuAppDbContext.FoodItems.FindAsync(foodItemId);
        }

        public async Task<List<FoodItem>> GetAllFoodItemsAsync()
        {
            return await _menuAppDbContext.FoodItems
            .Where(foodItem => !foodItem.IsInGallery)
            .ToListAsync();
        }

        public async Task<List<FoodItem>> GetFoodItemsByPriceAsync(decimal price)
        {
            return await _menuAppDbContext.FoodItems
                .Where(foodItems => foodItems.price <= price)
                .ToListAsync();
        }

        
        public async Task<List<FoodItem>> GetFoodItemsByVeganAsync(bool isVegan)
        {
            return await _menuAppDbContext.FoodItems
                .Where(foodItems => foodItems.isVegan == isVegan)
                .ToListAsync();
        }

        public async Task<List<FoodItem>> GetFoodItemsByCaloriesAsync(float maximumCalories)
        {
            return await _menuAppDbContext.FoodItems
                .Where(foodItems => foodItems.calories <= maximumCalories)
                .ToListAsync();
        }



        public async Task AddFoodItemAsync(FoodItem foodItem)
        {
            await _menuAppDbContext.FoodItems.AddAsync(foodItem);
            await _menuAppDbContext.SaveChangesAsync();
        }


        public async Task UpdateFoodItemAsync(FoodItem foodItem)
        {
            // Retrieve the existing food item from the database
            var existingFoodItem = await _menuAppDbContext.FoodItems.FindAsync(foodItem.id);

            // Update the properties of the existing food item with the new values
            existingFoodItem.name = foodItem.name;
            existingFoodItem.price = foodItem.price;
            existingFoodItem.category = foodItem.category;
            existingFoodItem.description = foodItem.description;

            // Mark the existing food item as modified
            _menuAppDbContext.Entry(existingFoodItem).State = EntityState.Modified;

            // Save the changes to the database
            await _menuAppDbContext.SaveChangesAsync();
        }

        public async Task DeleteFoodItemAsync(int foodItemId)
        {
            var foodItem = await _menuAppDbContext.FoodItems.FindAsync(foodItemId);
            if (foodItem != null)
            {
                _menuAppDbContext.FoodItems.Remove(foodItem);
                await _menuAppDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<FoodItem>> GetFoodItemsByCategoryAsync(string categoryName)
        {
            return await _menuAppDbContext.FoodItems
                .Where(foodItems => foodItems.category == categoryName)
                .ToListAsync();
        }

        public async Task<List<FoodItem>> GetGalleryItemsAsync()
        {
            return await _menuAppDbContext.FoodItems
                .Where(item => item.IsInGallery) 
                .ToListAsync();
        }


        public void Dispose()
        {
            _menuAppDbContext.Dispose();
        }
    }
}

