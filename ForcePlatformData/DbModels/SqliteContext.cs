﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Text;

namespace ForcePlatformData.DbModels
{
    public class SqliteContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserParams> UserParams { get; set; }
        public DbSet<Report> Reports { get; set; }

        public SqliteContext(DbContextOptionsBuilder options, string connectionString)
        {            
            options.UseSqlite(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_UserId");
            modelBuilder.Entity<User>().HasIndex(u => u.Id).IsUnique();
            modelBuilder.Entity<User>().HasOne(d => d.UserParams);
            modelBuilder.Entity<User>().HasMany(d => d.Reports);

            modelBuilder.Entity<UserParams>().ToTable("UserParams");
            modelBuilder.Entity<UserParams>().HasKey(u => u.Id).HasName("PK_UserParamId");
            modelBuilder.Entity<UserParams>().HasOne(u => u.User);

            modelBuilder.Entity<Report>().ToTable("Reports");
            modelBuilder.Entity<Report>().HasKey(u => u.Id).HasName("PK_ReportId");
            modelBuilder.Entity<Report>().HasOne(u => u.User);
        }
    }
}
