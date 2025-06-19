using Final_Project.Models.Common;

namespace Final_Project.Models
{
    public class Food : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
            public decimal Price { get; set; }
        public string ImageUrl { get; set; } = null!;
            public int CategoryId { get; set; }
            public Category? Category { get; set; }

            public bool IsAvailable { get; set; }  

            public ICollection<OrderItem>? OrderItems { get; set; }
        public ICollection<FoodIngredient> FoodIngredients { get; set; }





    }
}
