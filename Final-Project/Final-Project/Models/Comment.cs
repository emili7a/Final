using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Comment : BaseEntity
    {
            public int FoodId { get; set; }
            public Food? Food { get; set; }

            public string? UserName { get; set; }
            public string? Message { get; set; }
            public int Rating { get; set; }           
            public DateTime CreatedAt { get; set; } = DateTime.Now;
        

    }
}