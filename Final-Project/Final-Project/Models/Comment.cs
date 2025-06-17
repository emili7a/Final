using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Comment : BaseEntity
    {
        
            public string Text { get; set; }
            public int BlogId { get; set; }
        
    }
}