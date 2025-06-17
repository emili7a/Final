using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Order : BaseEntity
    {
    
        public DateTime OrderDate { get; set; }
        public List<OrderItem>? OrderItems { get; set; }
    }
}
