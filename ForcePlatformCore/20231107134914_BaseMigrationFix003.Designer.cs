﻿// <auto-generated />
using System;
using ForcePlatformCore.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForcePlatformCore.Migrations
{
    [DbContext(typeof(SqliteContext))]
    [Migration("20231107134914_BaseMigrationFix003")]
    partial class BaseMigrationFix003
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("ForcePlatformCore.DbModels.Report", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("PK_ReportId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Reports", (string)null);
                });

            modelBuilder.Entity("ForcePlatformCore.DbModels.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EditedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserParamsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id")
                        .HasName("PK_UserId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("UserParamsId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("ForcePlatformCore.DbModels.UserParams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("BodyHeight")
                        .HasColumnType("REAL");

                    b.Property<double?>("BodyWeight")
                        .HasColumnType("REAL");

                    b.Property<double?>("LeftShin")
                        .HasColumnType("REAL");

                    b.Property<double?>("LeftSole")
                        .HasColumnType("REAL");

                    b.Property<double?>("LeftTigh")
                        .HasColumnType("REAL");

                    b.Property<string>("LengthUnit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double?>("RightShin")
                        .HasColumnType("REAL");

                    b.Property<double?>("RightSole")
                        .HasColumnType("REAL");

                    b.Property<double?>("RightTigh")
                        .HasColumnType("REAL");

                    b.HasKey("Id")
                        .HasName("PK_UserParamId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("UserParams", (string)null);
                });

            modelBuilder.Entity("ForcePlatformCore.DbModels.Report", b =>
                {
                    b.HasOne("ForcePlatformCore.DbModels.User", "User")
                        .WithMany("Reports")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForcePlatformCore.DbModels.User", b =>
                {
                    b.HasOne("ForcePlatformCore.DbModels.UserParams", "UserParams")
                        .WithMany()
                        .HasForeignKey("UserParamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserParams");
                });

            modelBuilder.Entity("ForcePlatformCore.DbModels.User", b =>
                {
                    b.Navigation("Reports");
                });
#pragma warning restore 612, 618
        }
    }
}
