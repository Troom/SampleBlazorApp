﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(OrderContext))]
    partial class OrderContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Model.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("AdditionalInfo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AdditionalInfo = "",
                            ClientName = "John",
                            CreateDate = new DateTime(2023, 3, 31, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4350),
                            OrderPrice = 2m,
                            Status = 1
                        },
                        new
                        {
                            Id = 2L,
                            AdditionalInfo = "",
                            ClientName = "Client2",
                            CreateDate = new DateTime(2023, 3, 30, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4411),
                            OrderPrice = 1m,
                            Status = 2
                        },
                        new
                        {
                            Id = 3L,
                            AdditionalInfo = "",
                            ClientName = "Client3",
                            CreateDate = new DateTime(2023, 3, 29, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4416),
                            OrderPrice = 1m,
                            Status = 3
                        },
                        new
                        {
                            Id = 4L,
                            AdditionalInfo = "",
                            ClientName = "Client4",
                            CreateDate = new DateTime(2023, 3, 28, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4418),
                            OrderPrice = 1m,
                            Status = 1
                        },
                        new
                        {
                            Id = 5L,
                            AdditionalInfo = "",
                            ClientName = "Client5",
                            CreateDate = new DateTime(2023, 3, 27, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4420),
                            OrderPrice = 1m,
                            Status = 2
                        },
                        new
                        {
                            Id = 6L,
                            AdditionalInfo = "",
                            ClientName = "Client6",
                            CreateDate = new DateTime(2023, 3, 26, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4422),
                            OrderPrice = 1m,
                            Status = 3
                        },
                        new
                        {
                            Id = 7L,
                            AdditionalInfo = "",
                            ClientName = "Client7",
                            CreateDate = new DateTime(2023, 3, 25, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4424),
                            OrderPrice = 1m,
                            Status = 2
                        },
                        new
                        {
                            Id = 8L,
                            AdditionalInfo = "",
                            ClientName = "Client8",
                            CreateDate = new DateTime(2023, 3, 24, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4426),
                            OrderPrice = 1m,
                            Status = 1
                        },
                        new
                        {
                            Id = 9L,
                            AdditionalInfo = "",
                            ClientName = "Client9",
                            CreateDate = new DateTime(2023, 3, 23, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4427),
                            OrderPrice = 1m,
                            Status = 4
                        },
                        new
                        {
                            Id = 10L,
                            AdditionalInfo = "",
                            ClientName = "Client10",
                            CreateDate = new DateTime(2023, 3, 22, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4429),
                            OrderPrice = 1m,
                            Status = 1
                        },
                        new
                        {
                            Id = 11L,
                            AdditionalInfo = "",
                            ClientName = "Client11",
                            CreateDate = new DateTime(2023, 3, 21, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4432),
                            OrderPrice = 1m,
                            Status = 2
                        },
                        new
                        {
                            Id = 12L,
                            AdditionalInfo = "",
                            ClientName = "Client12",
                            CreateDate = new DateTime(2023, 3, 20, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4433),
                            OrderPrice = 1m,
                            Status = 1
                        },
                        new
                        {
                            Id = 13L,
                            AdditionalInfo = "",
                            ClientName = "Client13",
                            CreateDate = new DateTime(2023, 3, 19, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4435),
                            OrderPrice = 1m,
                            Status = 1
                        },
                        new
                        {
                            Id = 14L,
                            AdditionalInfo = "",
                            ClientName = "Client14",
                            CreateDate = new DateTime(2023, 3, 18, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4437),
                            OrderPrice = 1m,
                            Status = 2
                        },
                        new
                        {
                            Id = 15L,
                            AdditionalInfo = "",
                            ClientName = "Client15",
                            CreateDate = new DateTime(2023, 3, 17, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4438),
                            OrderPrice = 1m,
                            Status = 1
                        },
                        new
                        {
                            Id = 16L,
                            AdditionalInfo = "",
                            ClientName = "Client16",
                            CreateDate = new DateTime(2023, 3, 16, 19, 27, 41, 504, DateTimeKind.Local).AddTicks(4440),
                            OrderPrice = 1m,
                            Status = 4
                        });
                });

            modelBuilder.Entity("Domain.Model.OrderLine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("OrderId")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderLines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1L,
                            Price = 1m,
                            Product = "P1"
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 3L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 5,
                            OrderId = 4L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 6,
                            OrderId = 5L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 7,
                            OrderId = 6L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 8,
                            OrderId = 7L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 9,
                            OrderId = 8L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 10,
                            OrderId = 9L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 11,
                            OrderId = 10L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 12,
                            OrderId = 11L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 13,
                            OrderId = 12L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 14,
                            OrderId = 13L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 15,
                            OrderId = 14L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 16,
                            OrderId = 15L,
                            Price = 1m,
                            Product = "P2"
                        },
                        new
                        {
                            Id = 17,
                            OrderId = 16L,
                            Price = 1m,
                            Product = "P2"
                        });
                });

            modelBuilder.Entity("Domain.Model.OrderLine", b =>
                {
                    b.HasOne("Domain.Model.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Domain.Model.Order", b =>
                {
                    b.Navigation("OrderLines");
                });
#pragma warning restore 612, 618
        }
    }
}
