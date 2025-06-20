using Final_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Project.ViewModels.FoodViewModels
{
    public class FoodCreateVM
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int CategoryId { get; set; }

        public List<int> SelectedIngredientIds { get; set; } = new();
        public List<IngredientCheckboxItem> Ingredients { get; set; } = new();
    }



}
}
