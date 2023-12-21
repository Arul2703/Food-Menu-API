// using System.ComponentModel.DataAnnotations;

// namespace FoodMenuApi.Models{
//   public class FoodItem{
//      [Key]
//     public int Id { get; set; }
    
//     [Required]
//     public string Name { get; set; }

//     [Required]    
//     public int Price { get; set; }
    
//     [Required]
//     public string Description { get; set; }
    
//     [Required]
//     public string ImageUrl { get; set; }
    
//     [Required]
//     public string Category { get; set; }

//     [Required]
//     public bool IsVegan { get; set; }

//     [Required]
//     public float Calories { get; set; }
//   }
// }

using System.ComponentModel.DataAnnotations;

namespace FoodMenuApi.Models
{
    public class FoodItem
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int price { get; set; }

        [Required]
        public string description { get; set; }

        [Required]
        public byte[] imageUrl { get; set; }

        [Required]
        public string category { get; set; }

        [Required]
        public bool isVegan { get; set; }

        [Required]
        public float calories { get; set; }

        public bool IsInGallery { get; set; }
    }
}
