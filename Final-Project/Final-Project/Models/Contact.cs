using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Contact : BaseEntity
    {

        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Subject { get; set; } 
        public string Message { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public bool IsRead { get; set; } = false;
    }

}
