﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectShopping.DbContexts;

namespace ProjectShopping.Migrations
{
    [DbContext(typeof(ShopingDbContext))]
    partial class ShopingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectShopping.Entities.Cart", b =>
                {
                    b.Property<Guid>("CID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("OID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("CID");

                    b.HasIndex("OID");

                    b.HasIndex("PID");

                    b.HasIndex("UID");

                    b.ToTable("carts");
                });

            modelBuilder.Entity("ProjectShopping.Entities.Order", b =>
                {
                    b.Property<Guid>("OID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("dAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("oDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("total")
                        .HasColumnType("float");

                    b.HasKey("OID");

                    b.HasIndex("UID");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("ProjectShopping.Entities.Product", b =>
                {
                    b.Property<Guid>("PID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainCategory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("PID");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            PID = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            Description = "aasdf as dfgaskjdf askdfh askjdfh lasdf",
                            Gender = "Men",
                            MainCategory = "Shirt",
                            Name = "abcd",
                            Price = 20
                        });
                });

            modelBuilder.Entity("ProjectShopping.Entities.Stock", b =>
                {
                    b.Property<Guid>("PID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("color")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("size")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("PID", "color", "size");

                    b.ToTable("stocks");
                });

            modelBuilder.Entity("ProjectShopping.Entities.Tags", b =>
                {
                    b.Property<Guid>("PID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("tag")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PID", "tag");

                    b.ToTable("AllTags");

                    b.HasData(
                        new
                        {
                            PID = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            tag = "cotton"
                        },
                        new
                        {
                            PID = new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                            tag = "Full-sleves"
                        });
                });

            modelBuilder.Entity("ProjectShopping.Entities.User", b =>
                {
                    b.Property<Guid>("UID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("number")
                        .HasColumnType("int");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("UID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("ProjectShopping.Entities.Cart", b =>
                {
                    b.HasOne("ProjectShopping.Entities.Order", "order")
                        .WithMany("CartItems")
                        .HasForeignKey("OID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectShopping.Entities.Product", "prduct")
                        .WithMany("CartItems")
                        .HasForeignKey("PID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectShopping.Entities.User", "user")
                        .WithMany("CartItems")
                        .HasForeignKey("UID");

                    b.Navigation("order");

                    b.Navigation("prduct");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProjectShopping.Entities.Order", b =>
                {
                    b.HasOne("ProjectShopping.Entities.User", "user")
                        .WithMany("OrderHistory")
                        .HasForeignKey("UID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProjectShopping.Entities.Stock", b =>
                {
                    b.HasOne("ProjectShopping.Entities.Product", "product")
                        .WithMany("Inventory")
                        .HasForeignKey("PID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("ProjectShopping.Entities.Tags", b =>
                {
                    b.HasOne("ProjectShopping.Entities.Product", "product")
                        .WithMany("TagList")
                        .HasForeignKey("PID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("ProjectShopping.Entities.Order", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("ProjectShopping.Entities.Product", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("Inventory");

                    b.Navigation("TagList");
                });

            modelBuilder.Entity("ProjectShopping.Entities.User", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("OrderHistory");
                });
#pragma warning restore 612, 618
        }
    }
}
