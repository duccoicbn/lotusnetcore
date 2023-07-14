﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI_Final.Entities;

#nullable disable

namespace WebAPI_Final.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230712131814_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebAPI_Final.Entities.ProductDetaiPropertyDetails", b =>
                {
                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<int>("productDetailID")
                        .HasColumnType("int");

                    b.Property<int>("propertyDetailID")
                        .HasColumnType("int");

                    b.HasKey("productID", "productDetailID", "propertyDetailID");

                    b.HasIndex("productDetailID");

                    b.HasIndex("propertyDetailID");

                    b.ToTable("ProductDetaiPropertyDetails");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.ProductDetails", b =>
                {
                    b.Property<int>("productDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productDetailID"));

                    b.Property<int?>("parentID")
                        .HasColumnType("int");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.Property<string>("productDetailName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("propertyDetailID")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<double>("sellPrice")
                        .HasColumnType("float");

                    b.HasKey("productDetailID");

                    b.HasIndex("parentID");

                    b.HasIndex("propertyDetailID");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.Products", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("productID"));

                    b.Property<string>("productCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("productShowName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("productID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.Properties", b =>
                {
                    b.Property<int>("propertyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("propertyID"));

                    b.Property<int>("productID")
                        .HasColumnType("int");

                    b.Property<string>("propertyCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("propertyDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("propertySort")
                        .HasColumnType("int");

                    b.HasKey("propertyID");

                    b.HasIndex("productID");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.PropertyDetails", b =>
                {
                    b.Property<int>("propertyDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("propertyDetailID"));

                    b.Property<string>("propertyDetailCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("propertyDetailDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("propertyID")
                        .HasColumnType("int");

                    b.HasKey("propertyDetailID");

                    b.HasIndex("propertyID");

                    b.ToTable("PropertyDetails");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.ProductDetaiPropertyDetails", b =>
                {
                    b.HasOne("WebAPI_Final.Entities.ProductDetails", "ProductDetails")
                        .WithMany("ProductDetaiPropertyDetails")
                        .HasForeignKey("productDetailID")
                        .IsRequired();

                    b.HasOne("WebAPI_Final.Entities.Products", "Products")
                        .WithMany("ProductDetaiPropertyDetails")
                        .HasForeignKey("productID")
                        .IsRequired();

                    b.HasOne("WebAPI_Final.Entities.PropertyDetails", "PropertyDetails")
                        .WithMany("ProductDetaiPropertyDetails")
                        .HasForeignKey("propertyDetailID")
                        .IsRequired();

                    b.Navigation("ProductDetails");

                    b.Navigation("Products");

                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.ProductDetails", b =>
                {
                    b.HasOne("WebAPI_Final.Entities.ProductDetails", "ParentDetails")
                        .WithMany("LstParentDetails")
                        .HasForeignKey("parentID");

                    b.HasOne("WebAPI_Final.Entities.PropertyDetails", "PropertyDetails")
                        .WithMany("ProductDetails")
                        .HasForeignKey("propertyDetailID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentDetails");

                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.Properties", b =>
                {
                    b.HasOne("WebAPI_Final.Entities.Products", "Products")
                        .WithMany("Properties")
                        .HasForeignKey("productID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.PropertyDetails", b =>
                {
                    b.HasOne("WebAPI_Final.Entities.Properties", "Properties")
                        .WithMany("PropertyDetails")
                        .HasForeignKey("propertyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.ProductDetails", b =>
                {
                    b.Navigation("LstParentDetails");

                    b.Navigation("ProductDetaiPropertyDetails");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.Products", b =>
                {
                    b.Navigation("ProductDetaiPropertyDetails");

                    b.Navigation("Properties");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.Properties", b =>
                {
                    b.Navigation("PropertyDetails");
                });

            modelBuilder.Entity("WebAPI_Final.Entities.PropertyDetails", b =>
                {
                    b.Navigation("ProductDetaiPropertyDetails");

                    b.Navigation("ProductDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
