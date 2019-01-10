﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopa.Data;

namespace Shopa.Data.Migrations
{
    [DbContext(typeof(ShopaDbContext))]
    [Migration("20190110010956_Favorites")]
    partial class Favorites
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Shopa.Data.Models.Balance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Bills")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Outcome")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Rent")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Revenue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Taxes")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WorkerSalaries")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Balances");
                });

            modelBuilder.Entity("Shopa.Data.Models.Favorite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<string>("ShopaUserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("ShopaUserId");

                    b.ToTable("Favorite");
                });

            modelBuilder.Entity("Shopa.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Status");

                    b.Property<int?>("StoreId");

                    b.Property<DateTime>("TimeOfOrder");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Shopa.Data.Models.OrderProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("Shopa.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("PictureLocalPath");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("StoreId");

                    b.Property<DateTime>("TimeOfCreation");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shopa.Data.Models.Quantity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<decimal?>("LastBuyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductId");

                    b.Property<int>("QuantityAlert");

                    b.Property<int?>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("StoreId");

                    b.ToTable("Quantities");
                });

            modelBuilder.Entity("Shopa.Data.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId");

                    b.Property<int>("Rating");

                    b.Property<string>("Text");

                    b.Property<int>("UserId");

                    b.Property<string>("UserId1");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId1");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Shopa.Data.Models.ShopaUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateOfRegistration");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PicturePath");

                    b.Property<string>("SecurityStamp");

                    b.Property<int?>("StoreId");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("StoreId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Shopa.Data.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BalanceId");

                    b.HasKey("Id");

                    b.HasIndex("BalanceId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Shopa.Data.Models.ShopaUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Shopa.Data.Models.ShopaUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shopa.Data.Models.ShopaUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Shopa.Data.Models.ShopaUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shopa.Data.Models.Favorite", b =>
                {
                    b.HasOne("Shopa.Data.Models.Product", "Product")
                        .WithMany("Favorites")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shopa.Data.Models.ShopaUser", "ShopaUser")
                        .WithMany("Favorites")
                        .HasForeignKey("ShopaUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shopa.Data.Models.Order", b =>
                {
                    b.HasOne("Shopa.Data.Models.Store")
                        .WithMany("Orders")
                        .HasForeignKey("StoreId");

                    b.HasOne("Shopa.Data.Models.ShopaUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Shopa.Data.Models.OrderProduct", b =>
                {
                    b.HasOne("Shopa.Data.Models.Order", "Order")
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("Shopa.Data.Models.Product", "Product")
                        .WithMany("Products")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Shopa.Data.Models.Product", b =>
                {
                    b.HasOne("Shopa.Data.Models.Store")
                        .WithMany("Products")
                        .HasForeignKey("StoreId");

                    b.HasOne("Shopa.Data.Models.ShopaUser", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Shopa.Data.Models.Quantity", b =>
                {
                    b.HasOne("Shopa.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Shopa.Data.Models.Store")
                        .WithMany("Quantity")
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("Shopa.Data.Models.Review", b =>
                {
                    b.HasOne("Shopa.Data.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Shopa.Data.Models.ShopaUser", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId1");
                });

            modelBuilder.Entity("Shopa.Data.Models.ShopaUser", b =>
                {
                    b.HasOne("Shopa.Data.Models.Store")
                        .WithMany("Users")
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("Shopa.Data.Models.Store", b =>
                {
                    b.HasOne("Shopa.Data.Models.Balance", "Balance")
                        .WithMany("Stores")
                        .HasForeignKey("BalanceId");
                });
#pragma warning restore 612, 618
        }
    }
}
