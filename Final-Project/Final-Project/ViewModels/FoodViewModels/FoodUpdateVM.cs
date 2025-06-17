using Final_Project.ViewModels.CommonVM;

namespace Final_Project.ViewModels.FoodViewModels
{
    public class FoodUpdateVM : BaseVM
    {
     
            public string? Name { get; set; }
            public string? Description { get; set; }
            public decimal Price { get; set; }
            public bool IsAvailable { get; set; }

            public int CategoryId { get; set; }
            public int Porsion { get; set; }
            public string? ImageUrl { get; set; }
        
    }
}
}
