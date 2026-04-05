using Microsoft.EntityFrameworkCore;
using TravelBuddy.Models;
namespace TravelBuddy.Data
{
    public class DBContext : DbContext
    {
        public DbSet<Community> Community { get; set; }
        public DbSet<Usr> Usr { get; set; }
        public DbSet<CommunityChat> CommunityChat { get; set; }
        public DbSet<ChatFile> ChatFile { get; set; }
        public DbSet<Ride> Ride { get; set; }

        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Community>()
                .HasMany(c => c.communityChats)
                .WithOne(cc => cc.community)
                .HasForeignKey(cc => cc.communityId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Community>()
                .HasOne(c => c.usr)
                .WithMany(u => u.communities)
                .HasForeignKey(c => c.cemail)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Usr>()
                .HasMany(u => u.communityChats)
                .WithOne(cc => cc.usr)
                .HasForeignKey(cc => cc.usrEmail)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
