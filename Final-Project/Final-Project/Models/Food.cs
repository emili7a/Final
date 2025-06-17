using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Food : BaseEntity
    {

            public string? Name { get; set; } 
            public string? Description { get; set; } 
            public decimal Price { get; set; } 
            public string? ImageUrl { get; set; } 
            public bool IsAvailable { get; set; } 

 

            public int CategoryId { get; set; }
            public Category? Category { get; set; }

            public int Porsion { get; set; } 

            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
        


    }
}
