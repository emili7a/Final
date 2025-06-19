using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Order : BaseEntity
    {
        
            public int? CustomerId { get; set; }       
            public Customer Customer { get; set; }

            public int? TableId { get; set; }          
            public Table Table { get; set; }

            public DateTime OrderTime { get; set; } = DateTime.Now;
            public OrderStatus? Status { get; set; }    
            public decimal TotalAmount { get; set; }

            public ICollection<OrderItem> OrderItems { get; set; }
        

    }
}
