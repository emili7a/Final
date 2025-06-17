using Final_Project.ViewModels.CommonVM;

namespace Final_Project.ViewModels.FoodViewModels
{
    public class FoodGetVM :  BaseVM
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }
    }
}
