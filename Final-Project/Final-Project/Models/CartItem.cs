using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class CartItem : BaseEntity
    {
            public int FoodId { get; set; }
            public Food? Food { get; set; }

            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
      

    }
}
