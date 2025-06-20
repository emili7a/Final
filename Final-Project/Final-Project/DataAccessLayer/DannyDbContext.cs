using Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.DataAccessLayer
{
    public class DannyDbContext : IdentityDbContext<AppUser>
    {
        public DannyDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public object Contacts { get; internal set; }
        public IEnumerable<object> Ingredients { get; internal set; }
        public object Customers { get; internal set; }
    }
}