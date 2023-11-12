using ForcePlatformData.Models;
using Microsoft.EntityFrameworkCore;

namespace ForcePlatformData.DbModels
{
    public class SqliteContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserParams> UserParams { get; set; }
        public DbSet<Report> Reports { get; set; }

        //public SqliteContext(DbContextOptionsBuilder options)
        //{            
        //    options.UseSqlite("");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={Path.Join(AppConfig.CommonPath, AppConfig.DbName)}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_UserId");
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<User>().HasOne(d => d.UserParams);
            modelBuilder.Entity<User>().HasMany(d => d.Reports);

            modelBuilder.Entity<UserParams>().ToTable("UserParams");
            modelBuilder.Entity<UserParams>().HasKey(u => u.Id).HasName("PK_UserParamId");
            modelBuilder.Entity<UserParams>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<UserParams>().HasOne(d => d.User).WithOne(user=>user.UserParams);

            modelBuilder.Entity<Report>().ToTable("Reports");
            modelBuilder.Entity<Report>().HasKey(u => u.Id).HasName("PK_ReportId");
            modelBuilder.Entity<Report>().HasIndex(u => u.Id).IsUnique();

            modelBuilder.Entity<Report>().HasOne(u => u.User);
        }
    }
}
