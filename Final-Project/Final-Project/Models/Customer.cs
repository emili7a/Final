using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool IsRegistered { get; set; }   

        public ICollection<Order> Orders { get; set; }
    }

}
