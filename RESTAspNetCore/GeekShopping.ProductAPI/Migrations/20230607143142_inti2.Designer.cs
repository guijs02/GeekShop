﻿// <auto-generated />
using GeekShopping.ProductAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GeekShopping.ProductAPI.Migrations
{
    [DbContext(typeof(SQLServerContext))]
    [Migration("20230607143142_inti2")]
    partial class inti2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GeekShopping.ProductAPI.Model.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Categoria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Categoria = "t-shirt",
                            Descricao = "camisa legal",
                            ImageURL = "ShoppingImages/13_dragon_ball.jpg",
                            Nome = "Dragon ball",
                            Preco = 15.90m
                        },
                        new
                        {
                            Id = 2,
                            Categoria = "t-shirt",
                            Descricao = "camisa legal",
                            ImageURL = "ShoppingImages/12_gnu_linux.jpg",
                            Nome = "occupy mars",
                            Preco = 17.90m
                        },
                        new
                        {
                            Id = 3,
                            Categoria = "t-shirt",
                            Descricao = "camisa legal",
                            ImageURL = "ShoppingImages/12_gnu_linux.jpg",
                            Nome = "GNU",
                            Preco = 18.95m
                        },
                        new
                        {
                            Id = 4,
                            Categoria = "mascara",
                            Descricao = "mascara legal",
                            ImageURL = "ShoppingImages/3_vader.jpg",
                            Nome = "Dart vader",
                            Preco = 32.90m
                        },
                        new
                        {
                            Id = 5,
                            Categoria = "t-shirt",
                            Descricao = "camisa legal",
                            ImageURL = "ShoppingImages/6_spacex.jpg",
                            Nome = "SPACEX",
                            Preco = 10.90m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
