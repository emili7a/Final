using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Table : BaseEntity
    {
            public int TableNumber { get; set; }       
            public int Capacity { get; set; }         
            public bool IsOccupied { get; set; }       

            public ICollection<Order> Orders { get; set; }
        
    }
}
