using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class CartItem : BaseEntity
    {

        public int Id { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int Quantity { get; set; }

        public string? SessionId { get; set; }  

        public string? UserId { get; set; }    
        public AppUser? User { get; set; }

    }
}
