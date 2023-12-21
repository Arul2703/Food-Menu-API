using System.ComponentModel.DataAnnotations;

namespace FoodMenuApi.Models{
  public class FoodCategory{
     public string name { get; set; }
    
    public List<FoodItem> items { get; set; }
  }
} 