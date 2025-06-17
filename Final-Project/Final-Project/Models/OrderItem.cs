using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class OrderItem : BaseEntity
    {
        public int FoodId { get; set; }
        public Food? Food { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice => Quantity * UnitPrice;
    }
}
