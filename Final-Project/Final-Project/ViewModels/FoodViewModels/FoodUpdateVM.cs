using Final_Project.ViewModels.CommonVM;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Final_Project.ViewModels.FoodViewModels
{
    public class FoodUpdateVM : BaseVM
    { 

            public string? Name { get; set; }
            public string? Description { get; set; }
            public decimal Price { get; set; }

            public int CategoryId { get; set; }

            public List<int> SelectedIngredientIds { get; set; } = new();

            public List<SelectListItem> Categories { get; set; } = new();
            public List<IngredientCheckboxItem> Ingredients { get; set; } = new();
        


    }
}
}
