﻿// <auto-generated />
using System;
using BookLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookLibrary.Data.Migrations
{
    [DbContext(typeof(BookLibraryContext))]
    [Migration("20221111133253_FixSeedData")]
    partial class FixSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookBorrowRequest", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("BorrowRequestsId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "BorrowRequestsId");

                    b.HasIndex("BorrowRequestsId");

                    b.ToTable("BorrowRequestDetails", (string)null);

                    b.HasData(
                        new
                        {
                            BooksId = 1,
                            BorrowRequestsId = 1
                        },
                        new
                        {
                            BooksId = 2,
                            BorrowRequestsId = 1
                        },
                        new
                        {
                            BooksId = 3,
                            BorrowRequestsId = 1
                        },
                        new
                        {
                            BooksId = 4,
                            BorrowRequestsId = 2
                        },
                        new
                        {
                            BooksId = 5,
                            BorrowRequestsId = 2
                        },
                        new
                        {
                            BooksId = 6,
                            BorrowRequestsId = 2
                        },
                        new
                        {
                            BooksId = 1,
                            BorrowRequestsId = 2
                        },
                        new
                        {
                            BooksId = 2,
                            BorrowRequestsId = 2
                        },
                        new
                        {
                            BooksId = 3,
                            BorrowRequestsId = 3
                        },
                        new
                        {
                            BooksId = 4,
                            BorrowRequestsId = 3
                        });
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "CategoriesId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("BookCategories", (string)null);

                    b.HasData(
                        new
                        {
                            BooksId = 1,
                            CategoriesId = 1
                        },
                        new
                        {
                            BooksId = 2,
                            CategoriesId = 2
                        },
                        new
                        {
                            BooksId = 3,
                            CategoriesId = 2
                        },
                        new
                        {
                            BooksId = 4,
                            CategoriesId = 3
                        },
                        new
                        {
                            BooksId = 5,
                            CategoriesId = 3
                        },
                        new
                        {
                            BooksId = 6,
                            CategoriesId = 3
                        },
                        new
                        {
                            BooksId = 3,
                            CategoriesId = 1
                        },
                        new
                        {
                            BooksId = 4,
                            CategoriesId = 2
                        });
                });

            modelBuilder.Entity("BookLibrary.Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cover")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Books", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cover = "https://dummyimage.com/300x450/",
                            Name = "Harry Potter"
                        },
                        new
                        {
                            Id = 2,
                            Cover = "https://dummyimage.com/300x450/",
                            Name = "Homo Sapiens"
                        },
                        new
                        {
                            Id = 3,
                            Cover = "https://dummyimage.com/300x450/",
                            Name = "Homo Deus"
                        },
                        new
                        {
                            Id = 4,
                            Cover = "https://dummyimage.com/300x450/",
                            Name = "Algorithm"
                        },
                        new
                        {
                            Id = 5,
                            Cover = "https://dummyimage.com/300x450/",
                            Name = "Clean Code"
                        },
                        new
                        {
                            Id = 6,
                            Cover = "https://dummyimage.com/300x450/",
                            Name = "Head First: Design Pattern"
                        });
                });

            modelBuilder.Entity("BookLibrary.Data.Entities.BorrowRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("ApprovedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ApprovedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestedBy")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApprovedBy");

                    b.HasIndex("RequestedBy");

                    b.ToTable("BorrowRequests", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RequestedAt = new DateTime(2022, 11, 11, 20, 32, 53, 590, DateTimeKind.Local).AddTicks(3714),
                            RequestedBy = 1,
                            Status = 0
                        },
                        new
                        {
                            Id = 2,
                            ApprovedAt = new DateTime(2022, 11, 11, 20, 32, 53, 590, DateTimeKind.Local).AddTicks(3724),
                            ApprovedBy = 3,
                            RequestedAt = new DateTime(2022, 11, 11, 20, 32, 53, 590, DateTimeKind.Local).AddTicks(3723),
                            RequestedBy = 1,
                            Status = 1
                        },
                        new
                        {
                            Id = 3,
                            ApprovedAt = new DateTime(2022, 11, 11, 20, 32, 53, 590, DateTimeKind.Local).AddTicks(3728),
                            ApprovedBy = 4,
                            RequestedAt = new DateTime(2022, 11, 11, 20, 32, 53, 590, DateTimeKind.Local).AddTicks(3727),
                            RequestedBy = 2,
                            Status = 2
                        });
                });

            modelBuilder.Entity("BookLibrary.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fiction"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Science"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Technology"
                        });
                });

            modelBuilder.Entity("BookLibrary.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Normal 1",
                            Password = "normie1",
                            Role = 0,
                            Username = "normie1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Normal 2",
                            Password = "normie2",
                            Role = 0,
                            Username = "normie2"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Super 1",
                            Password = "supreme1",
                            Role = 1,
                            Username = "supreme1"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Super 2",
                            Password = "supreme2",
                            Role = 1,
                            Username = "supreme2"
                        });
                });

            modelBuilder.Entity("BookBorrowRequest", b =>
                {
                    b.HasOne("BookLibrary.Data.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookLibrary.Data.Entities.BorrowRequest", null)
                        .WithMany()
                        .HasForeignKey("BorrowRequestsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookCategory", b =>
                {
                    b.HasOne("BookLibrary.Data.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookLibrary.Data.Entities.Category", null)
                        .WithMany()
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookLibrary.Data.Entities.BorrowRequest", b =>
                {
                    b.HasOne("BookLibrary.Data.Entities.User", "Approver")
                        .WithMany("ApprovedBorrowRequests")
                        .HasForeignKey("ApprovedBy");

                    b.HasOne("BookLibrary.Data.Entities.User", "Requester")
                        .WithMany("RequestedBorrowRequests")
                        .HasForeignKey("RequestedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("BookLibrary.Data.Entities.User", b =>
                {
                    b.Navigation("ApprovedBorrowRequests");

                    b.Navigation("RequestedBorrowRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
