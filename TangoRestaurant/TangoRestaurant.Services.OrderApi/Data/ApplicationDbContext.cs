using Microsoft.EntityFrameworkCore;
using TangoRestaurant.Services.OrderApi.Data.Models;

namespace TangoRestaurant.Services.OrderApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
