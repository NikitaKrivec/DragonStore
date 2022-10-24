using Microsoft.EntityFrameworkCore;
using Monster_Review_Store.Models;

namespace Monster_Review_Store.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) //base show all data 
        {

        }
        // create a tables - creating data context
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Monster> Monster { get; set; }
        public DbSet<MonsterOwner> MonsterOwners { get; set; }
        public DbSet<MonsterCategory> MonsterCategories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //manipulate tables
        {
            modelBuilder.Entity<MonsterCategory>()
                .HasKey(mc => new { mc.MonsterId, mc.CategoryId });
            modelBuilder.Entity<MonsterCategory>()
                    .HasOne(m => m.Monsters)
                    .WithMany(mc => mc.MonsterCategories)
                    .HasForeignKey(m => m.MonsterId);
            modelBuilder.Entity<MonsterCategory>()
                    .HasOne(m => m.Category)
                    .WithMany(mc => mc.MonsterCategories)
                    .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<MonsterOwner>()
                .HasKey(mo => new { mo.MonsterId, mo.OwnerId });
            modelBuilder.Entity<MonsterOwner>()
                    .HasOne(m => m.Monster)
                    .WithMany(mo => mo.MonsterOwners)
                    .HasForeignKey(m => m.MonsterId);
            modelBuilder.Entity<MonsterOwner>()
                    .HasOne(m => m.Owner)
                    .WithMany(mo => mo.MonsterOwners)
                    .HasForeignKey(c => c.OwnerId);
        }
    }
}
