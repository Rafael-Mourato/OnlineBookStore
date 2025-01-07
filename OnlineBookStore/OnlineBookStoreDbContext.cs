using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Models;

namespace OnlineBookStore
{
    public class OnlineBookStoreDbContext : DbContext
    {
        public OnlineBookStoreDbContext(DbContextOptions<OnlineBookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }

    }
}
