using CRUD_MVC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_MVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
    }
}
