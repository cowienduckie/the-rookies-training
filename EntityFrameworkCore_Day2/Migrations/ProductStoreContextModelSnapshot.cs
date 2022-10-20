﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductStore.Data;

#nullable disable

namespace ProductStore.Migrations
{
    [DbContext(typeof(ProductStoreContext))]
    partial class ProductStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProductStore.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Meat"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Bakery"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Beverage"
                        });
                });

            modelBuilder.Entity("ProductStore.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Manufacture")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Manufacture = "VN",
                            Name = "Pork"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Manufacture = "US",
                            Name = "Beef"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Manufacture = "VN",
                            Name = "White Bread"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Manufacture = "JP",
                            Name = "Coke"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Manufacture = "US",
                            Name = "Sprite"
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 3,
                            Manufacture = "VN",
                            Name = "Fanta"
                        });
                });

            modelBuilder.Entity("ProductStore.Data.Entities.Product", b =>
                {
                    b.HasOne("ProductStore.Data.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ProductStore.Data.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}