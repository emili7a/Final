using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Ingredient : BaseEntity
    {
        public string? Name { get; set; }  

        public ICollection<FoodIngredient>? FoodIngredients { get; set; }
    }

}