﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Warehouse.Persistence;

#nullable disable

namespace Warehouse.Persistence.Migrations
{
    [DbContext(typeof(WarehouseContext))]
    [Migration("20250210232711_Operations1")]
    partial class Operations1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Warehouse.Domain.Entities.BaseOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTimeOffset>("OperationDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("operation_date");

                    b.Property<string>("operation_type")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)")
                        .HasColumnName("operation_type");

                    b.HasKey("Id")
                        .HasName("pk_operations");

                    b.ToTable("operations", (string)null);

                    b.HasDiscriminator<string>("operation_type").HasValue("BaseOperation");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.OperationItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseOperationId")
                        .HasColumnType("integer")
                        .HasColumnName("base_operation_id");

                    b.Property<int>("Count")
                        .HasColumnType("integer")
                        .HasColumnName("count");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<int>("WarehouseItemId")
                        .HasColumnType("integer")
                        .HasColumnName("warehouse_item_id");

                    b.HasKey("Id")
                        .HasName("pk_operation_items");

                    b.HasIndex("BaseOperationId")
                        .HasDatabaseName("ix_operation_items_base_operation_id");

                    b.HasIndex("WarehouseItemId")
                        .HasDatabaseName("ix_operation_items_warehouse_item_id");

                    b.ToTable("operation_items", (string)null);
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.WarehouseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BookId")
                        .HasColumnType("integer")
                        .HasColumnName("book_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasKey("Id")
                        .HasName("pk_warehouse_items");

                    b.ToTable("warehouse_items", (string)null);
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.ReceiptOperation", b =>
                {
                    b.HasBaseType("Warehouse.Domain.Entities.BaseOperation");

                    b.HasDiscriminator().HasValue("ReceiptOperation");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.WriteOffOperation", b =>
                {
                    b.HasBaseType("Warehouse.Domain.Entities.BaseOperation");

                    b.HasDiscriminator().HasValue("WriteOffOperation");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.OperationItem", b =>
                {
                    b.HasOne("Warehouse.Domain.Entities.BaseOperation", "BaseOperation")
                        .WithMany("OperationItems")
                        .HasForeignKey("BaseOperationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_operation_items_base_operations_base_operation_id");

                    b.HasOne("Warehouse.Domain.Entities.WarehouseItem", "WarehouseItem")
                        .WithMany()
                        .HasForeignKey("WarehouseItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_operation_items_warehouse_items_warehouse_item_id");

                    b.Navigation("BaseOperation");

                    b.Navigation("WarehouseItem");
                });

            modelBuilder.Entity("Warehouse.Domain.Entities.BaseOperation", b =>
                {
                    b.Navigation("OperationItems");
                });
#pragma warning restore 612, 618
        }
    }
}
