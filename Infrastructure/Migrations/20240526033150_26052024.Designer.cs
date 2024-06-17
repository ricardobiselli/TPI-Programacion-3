﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240526033150_26052024")]
    partial class _26052024
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("Domain.Models.Compatibility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ram")
                        .HasColumnType("TEXT");

                    b.Property<string>("Series")
                        .HasColumnType("TEXT");

                    b.Property<string>("Socket")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Compatibilities");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("TEXT");

                    b.HasKey("OrderId");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Models.Payment", b =>
                {
                    b.Property<int?>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("PaymentStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("PaymentId");

                    b.HasIndex("ClientId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("OrderId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PowerConsumption")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ShoppingCartCartId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ShoppingCartCartId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Models.ShoppingCart", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("CartId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Models.AdminClass", b =>
                {
                    b.HasBaseType("Domain.Models.User");

                    b.HasDiscriminator().HasValue("AdminClass");
                });

            modelBuilder.Entity("Domain.Models.Client", b =>
                {
                    b.HasBaseType("Domain.Models.User");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DniNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("ZipCode")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Domain.Models.SuperAdmin", b =>
                {
                    b.HasBaseType("Domain.Models.AdminClass");

                    b.HasDiscriminator().HasValue("SuperAdmin");
                });

            modelBuilder.Entity("Domain.Models.Compatibility", b =>
                {
                    b.HasOne("Domain.Models.Product", null)
                        .WithMany("Compatibilities")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.HasOne("Domain.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Domain.Models.Payment", b =>
                {
                    b.HasOne("Domain.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.HasOne("Domain.Models.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("Domain.Models.ShoppingCart", null)
                        .WithMany("Products")
                        .HasForeignKey("ShoppingCartCartId");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Navigation("Compatibilities");
                });

            modelBuilder.Entity("Domain.Models.ShoppingCart", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
