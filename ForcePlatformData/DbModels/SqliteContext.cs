using ForcePlatformData.Models;
using Microsoft.EntityFrameworkCore;

namespace ForcePlatformData.DbModels
{
    public class SqliteContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserParams> UserParams { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ExerciseType> ExerciseType { get; set; }

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
            modelBuilder.Entity<UserParams>().HasOne(d => d.User).WithOne(user => user.UserParams);

            modelBuilder.Entity<Report>().ToTable("Reports");
            modelBuilder.Entity<Report>().HasKey(u => u.Id).HasName("PK_ReportId");
            modelBuilder.Entity<Report>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<Report>().HasIndex(u => u.Id).IsUnique();

            modelBuilder.Entity<Report>().HasOne(u => u.User);
            modelBuilder.Entity<Report>().HasOne(d => d.ExerciseType);

            modelBuilder.Entity<ExerciseType>().ToTable("ExerciseTypes");
            modelBuilder.Entity<ExerciseType>().HasKey(u => u.Id).HasName("PK_ExerciseTypeId");
            modelBuilder.Entity<ExerciseType>().HasData(
            new ExerciseType { Id = 1, Name = "Stability, 1st platform" },
            new ExerciseType { Id = 2, Name = "Jump, 2 platforms" },
            new ExerciseType { Id = 3, Name = "Gait, 4 platforms" });
        }
    }
}

//PM> Add-Migration BasMigration001 -Project ForcePlatformData -StartupProject ForcePlatformCore -Context SqliteContext 
//PM> Update-Database -Project ForcePlatformData -StartupProject ForcePlatformCore -Context SqliteContext 
