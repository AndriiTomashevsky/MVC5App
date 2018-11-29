using Mvc5App.Domain.Entities;
using System.Data.Entity;

namespace Mvc5App.Domain.Repository
{
    public class AppDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
