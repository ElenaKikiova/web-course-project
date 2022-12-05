﻿// <auto-generated />
using CourseProject.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseProject.Migrations
{
    [DbContext(typeof(NoFakeShoesDbContext))]
    [Migration("20221205064954_DiscountOneToManyRelationMigration")]
    partial class DiscountOneToManyRelationMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CourseProject.Models.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("DiscountPercentage")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("CourseProject.Models.Shoe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("DiscountId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.ToTable("Shoes");
                });

            modelBuilder.Entity("CourseProject.Models.Shoe_ShoeSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ShoeId")
                        .HasColumnType("int");

                    b.Property<int>("ShoeSupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShoeId");

                    b.HasIndex("ShoeSupplierId");

                    b.ToTable("Shoe_ShoeSuppliers");
                });

            modelBuilder.Entity("CourseProject.Models.ShoeSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShoeSuppliers");
                });

            modelBuilder.Entity("CourseProject.Models.Shoe", b =>
                {
                    b.HasOne("CourseProject.Models.Discount", "Discount")
                        .WithMany("Shoes")
                        .HasForeignKey("DiscountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("CourseProject.Models.Shoe_ShoeSupplier", b =>
                {
                    b.HasOne("CourseProject.Models.Shoe", "Shoe")
                        .WithMany("Shoe_ShoeSuppliers")
                        .HasForeignKey("ShoeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CourseProject.Models.ShoeSupplier", "ShoeSupplier")
                        .WithMany("Shoe_ShoeSuppliers")
                        .HasForeignKey("ShoeSupplierId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Shoe");

                    b.Navigation("ShoeSupplier");
                });

            modelBuilder.Entity("CourseProject.Models.Discount", b =>
                {
                    b.Navigation("Shoes");
                });

            modelBuilder.Entity("CourseProject.Models.Shoe", b =>
                {
                    b.Navigation("Shoe_ShoeSuppliers");
                });

            modelBuilder.Entity("CourseProject.Models.ShoeSupplier", b =>
                {
                    b.Navigation("Shoe_ShoeSuppliers");
                });
#pragma warning restore 612, 618
        }
    }
}
