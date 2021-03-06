﻿// <auto-generated />
using System;
using DroneStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DroneStore.Data.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20190822104043_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DroneStore.Core.Entities.Catalog.CatalogItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime>("CreatedinUtc");

                    b.Property<int?>("DiscountId");

                    b.Property<int>("ImageId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId")
                        .IsUnique()
                        .HasFilter("[DiscountId] IS NOT NULL");

                    b.HasIndex("ImageId");

                    b.ToTable("CatalogItems");
                });

            modelBuilder.Entity("DroneStore.Core.Entities.Currency.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("LastUpdateInUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Quote")
                        .IsRequired();

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Source")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("DroneStore.Core.Entities.Discounts.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpireDateInUtc")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("NewValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OldValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDateInUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("DroneStore.Core.Entities.Media.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("BinaryFile")
                        .IsRequired()
                        .HasColumnType("image");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("DroneStore.Core.Entities.Orders.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<string>("Address2")
                        .HasMaxLength(250);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerEmail")
                        .IsRequired()
                        .HasMaxLength(350);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<decimal>("OrderDiscount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OrderSubTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PaidDate");

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(150);

                    b.Property<string>("PaymentStatus")
                        .HasMaxLength(150);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("PhoneNumber2")
                        .HasMaxLength(50);

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("DroneStore.Core.Entities.Orders.OrderItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId")
                        .HasMaxLength(20);

                    b.Property<int>("Quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("DroneStore.Core.Entities.Catalog.CatalogItem", b =>
                {
                    b.HasOne("DroneStore.Core.Entities.Discounts.Discount", "Discount")
                        .WithOne()
                        .HasForeignKey("DroneStore.Core.Entities.Catalog.CatalogItem", "DiscountId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("DroneStore.Core.Entities.Media.Image", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DroneStore.Core.Entities.Orders.OrderItem", b =>
                {
                    b.HasOne("DroneStore.Core.Entities.Orders.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
