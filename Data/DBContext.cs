using Microsoft.EntityFrameworkCore;
using TravelBuddy.Models;
namespace TravelBuddy.Data
{
    public class DBContext:DbContext
    {
        public DbSet<Community> Community { get; set; }
        public DbSet<Usr> Usr { get; set; }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }
    }
}
