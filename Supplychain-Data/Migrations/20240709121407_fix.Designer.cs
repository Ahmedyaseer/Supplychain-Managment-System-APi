﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Supplychain_Data.SystemContext;

#nullable disable

namespace Supplychain_Data.Migrations
{
    [DbContext(typeof(SystemDbContext))]
    [Migration("20240709121407_fix")]
    partial class fix
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Supplychain_Data.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Eamil")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Supplychain_Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WarehouseId")
                        .IsUnique();

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Supplychain_Data.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasuringUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Supplychain_Data.Models.OrderSupply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderSupplyDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

                    b.Property<string>("Sequence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("OrderSupply");
                });

            modelBuilder.Entity("Supplychain_Data.Models.OrderSupplyItems", b =>
                {
                    b.Property<int>("OrderSupplyId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpirationTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2025, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

                    b.Property<DateTime>("ProductionTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("OrderSupplyId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("OrderSupplyItems");
                });

            modelBuilder.Entity("Supplychain_Data.Models.PickingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PickingListTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2024, 7, 9, 15, 14, 0, 0, DateTimeKind.Unspecified));

                    b.Property<Guid>("Sequence")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("PickingLists");
                });

            modelBuilder.Entity("Supplychain_Data.Models.PickingListItems", b =>
                {
                    b.Property<int>("PickingListId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PickingListId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("pickingListItems");
                });

            modelBuilder.Entity("Supplychain_Data.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<string>("WebSite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("Supplychain_Data.Models.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("Supplychain_Data.Models.WarehouseItem", b =>
                {
                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("WarehouseId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("WarehouseItems");
                });

            modelBuilder.Entity("Supplychain_Data.Models.Employee", b =>
                {
                    b.HasOne("Supplychain_Data.Models.Warehouse", "Warehouse")
                        .WithOne("Employee")
                        .HasForeignKey("Supplychain_Data.Models.Employee", "WarehouseId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Supplychain_Data.Models.OrderSupply", b =>
                {
                    b.HasOne("Supplychain_Data.Models.Supplier", "Supplier")
                        .WithMany("OrderSupplies")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Supplychain_Data.Models.Warehouse", "Warehouse")
                        .WithMany("OrderSupplies")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Supplychain_Data.Models.OrderSupplyItems", b =>
                {
                    b.HasOne("Supplychain_Data.Models.Item", "Item")
                        .WithMany("OrderSupplyItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Supplychain_Data.Models.OrderSupply", "OrderSupply")
                        .WithMany("OrderSupplyItems")
                        .HasForeignKey("OrderSupplyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("OrderSupply");
                });

            modelBuilder.Entity("Supplychain_Data.Models.PickingList", b =>
                {
                    b.HasOne("Supplychain_Data.Models.Customer", "Customer")
                        .WithMany("PickingLists")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Supplychain_Data.Models.Warehouse", "Warehouse")
                        .WithMany("PickingLists")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Supplychain_Data.Models.PickingListItems", b =>
                {
                    b.HasOne("Supplychain_Data.Models.Item", "Item")
                        .WithMany("PickingListItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Supplychain_Data.Models.PickingList", "PickingList")
                        .WithMany("PickingListItems")
                        .HasForeignKey("PickingListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("PickingList");
                });

            modelBuilder.Entity("Supplychain_Data.Models.WarehouseItem", b =>
                {
                    b.HasOne("Supplychain_Data.Models.Item", "Item")
                        .WithMany("WarehouseItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Supplychain_Data.Models.Warehouse", "Warehouse")
                        .WithMany("WearhouseItems")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("Supplychain_Data.Models.Customer", b =>
                {
                    b.Navigation("PickingLists");
                });

            modelBuilder.Entity("Supplychain_Data.Models.Item", b =>
                {
                    b.Navigation("OrderSupplyItems");

                    b.Navigation("PickingListItems");

                    b.Navigation("WarehouseItems");
                });

            modelBuilder.Entity("Supplychain_Data.Models.OrderSupply", b =>
                {
                    b.Navigation("OrderSupplyItems");
                });

            modelBuilder.Entity("Supplychain_Data.Models.PickingList", b =>
                {
                    b.Navigation("PickingListItems");
                });

            modelBuilder.Entity("Supplychain_Data.Models.Supplier", b =>
                {
                    b.Navigation("OrderSupplies");
                });

            modelBuilder.Entity("Supplychain_Data.Models.Warehouse", b =>
                {
                    b.Navigation("Employee")
                        .IsRequired();

                    b.Navigation("OrderSupplies");

                    b.Navigation("PickingLists");

                    b.Navigation("WearhouseItems");
                });
#pragma warning restore 612, 618
        }
    }
}
