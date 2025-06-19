using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Payment : BaseEntity
    {
            public int OrderId { get; set; }
            public Order? Order { get; set; }

            public decimal Amount { get; set; }
            public DateTime PaidAt { get; set; }
            public PaymentMethod Method { get; set; }
            public bool IsSuccessful { get; set; }
        

       
    }
}
