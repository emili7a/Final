using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
