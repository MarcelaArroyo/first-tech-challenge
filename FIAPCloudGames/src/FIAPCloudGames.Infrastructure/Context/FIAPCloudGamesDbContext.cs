using FIAPCloudGames.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FIAPCloudGames.Infrastructure.Context
{
    public class FIAPCloudGamesDbContext(DbContextOptions<FIAPCloudGamesDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserId);
        }
    }
}
