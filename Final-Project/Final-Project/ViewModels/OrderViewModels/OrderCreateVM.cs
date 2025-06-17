using Final_Project.ViewModels.OrderItemViewModels;

namespace Final_Project.ViewModels.OrderViewModels
{
    public class OrderCreateVM
    {
        public int CustomerId { get; set; }
        public List<OrderItemCreateVM> Items { get; set; } = new List<OrderItemCreateVM>();
    }
}
