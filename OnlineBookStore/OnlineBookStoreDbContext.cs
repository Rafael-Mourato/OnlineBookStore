using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineBookStore.Models;

namespace OnlineBookStore
{
    public class OnlineBookStoreDbContext : IdentityDbContext
    {
        public OnlineBookStoreDbContext(DbContextOptions<OnlineBookStoreDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Book { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;

    }
}