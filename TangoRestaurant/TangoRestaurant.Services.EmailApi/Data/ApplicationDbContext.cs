using Microsoft.EntityFrameworkCore;
using TangoRestaurant.Services.EmailApi.Data.Models;

namespace TangoRestaurant.Services.EmailApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EmailLog> EmailLogs { get; set; }

    }
}
