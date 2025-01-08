using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Models;

namespace OnlineBookStore
{
    public class OnlineBookStoreDbContext : DbContext
    {
        public OnlineBookStoreDbContext(DbContextOptions<OnlineBookStoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Book> Book { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;
    }
}