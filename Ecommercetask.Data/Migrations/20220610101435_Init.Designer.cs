﻿// <auto-generated />
using System;
using Ecommercetask.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ecommercetask.Data.Migrations
{
    [DbContext(typeof(EcommerceSiteContext))]
    [Migration("20220610101435_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ecommercetask.Data.Data.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address_Type")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("address_type");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("country");

                    b.Property<string>("House")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("house");

                    b.Property<int?>("Order_Details_Id")
                        .HasColumnType("int")
                        .HasColumnName("order_details_id");

                    b.Property<string>("Pincode")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("pincode");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("street");

                    b.Property<int?>("User_Id")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("Order_Details_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("type");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("value");

                    b.HasKey("Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Discount");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<decimal>("Total_Amount")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("total_amount");

                    b.Property<decimal>("Total_Discount")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("total_discount");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<int>("User_Id")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Order_Details", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int>("Discount_Id")
                        .HasColumnType("int")
                        .HasColumnName("discount_id");

                    b.Property<int>("Order_Id")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("status");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Discount_Id");

                    b.HasIndex("Order_Id");

                    b.HasIndex("Product_Id");

                    b.ToTable("Order_Details");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("brand");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("image");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,3)")
                        .HasColumnName("price");

                    b.Property<string>("Product_Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("product_name");

                    b.Property<int>("Product_Subcategory_Id")
                        .HasColumnType("int")
                        .HasColumnName("product_subcategory_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Product_Subcategory_Id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product_cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(6,2)")
                        .HasColumnName("price");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<int>("User_Id")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("Product_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Product_cart");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product_category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<bool>("Is_Active")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("Product_category");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product_subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Category_Id")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("name");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("Category_Id");

                    b.ToTable("Product_subcategory");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product_wishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<int>("Product_Id")
                        .HasColumnType("int")
                        .HasColumnName("product_id");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<int>("User_Id")
                        .HasColumnType("int")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("Product_Id");

                    b.HasIndex("User_Id");

                    b.ToTable("Product_wishlist");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasColumnName("age");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime")
                        .HasColumnName("created_at");

                    b.Property<string>("Email_Id")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("email_id");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("gender");

                    b.Property<string>("Phoneno")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("phoneno");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("role");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at");

                    b.Property<string>("User_Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Ecommercetask.Data.Model.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Address", b =>
                {
                    b.HasOne("Ecommercetask.Data.Data.Order_Details", "Order_Details")
                        .WithMany("Address")
                        .HasForeignKey("Order_Details_Id");

                    b.HasOne("Ecommercetask.Data.Data.User", "User")
                        .WithMany("Address")
                        .HasForeignKey("User_Id");

                    b.Navigation("Order_Details");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Discount", b =>
                {
                    b.HasOne("Ecommercetask.Data.Data.Product", "Product")
                        .WithMany("Discount")
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Order", b =>
                {
                    b.HasOne("Ecommercetask.Data.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Order_Details", b =>
                {
                    b.HasOne("Ecommercetask.Data.Data.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("Discount_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommercetask.Data.Data.Order", "Order")
                        .WithMany()
                        .HasForeignKey("Order_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommercetask.Data.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Discount");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product", b =>
                {
                    b.HasOne("Ecommercetask.Data.Data.Product_subcategory", "Product_subcategory")
                        .WithMany("Product")
                        .HasForeignKey("Product_Subcategory_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product_subcategory");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product_cart", b =>
                {
                    b.HasOne("Ecommercetask.Data.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommercetask.Data.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product_subcategory", b =>
                {
                    b.HasOne("Ecommercetask.Data.Data.Product_category", "Product_category")
                        .WithMany("Product_subcategory")
                        .HasForeignKey("Category_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product_category");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product_wishlist", b =>
                {
                    b.HasOne("Ecommercetask.Data.Data.Product", "Product")
                        .WithMany()
                        .HasForeignKey("Product_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommercetask.Data.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Ecommercetask.Data.Model.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Ecommercetask.Data.Model.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ecommercetask.Data.Model.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Ecommercetask.Data.Model.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Order_Details", b =>
                {
                    b.Navigation("Address");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product", b =>
                {
                    b.Navigation("Discount");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product_category", b =>
                {
                    b.Navigation("Product_subcategory");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.Product_subcategory", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommercetask.Data.Data.User", b =>
                {
                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
