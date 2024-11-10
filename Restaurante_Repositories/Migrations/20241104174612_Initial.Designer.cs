﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Restaurante_Repositories.DataContext;

#nullable disable

namespace Restaurante_Repositories.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241104174612_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Restaurante_Borders.Entities.Restaurante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Restaurante");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f6f74d3-4727-493f-91f5-5a66713ab7f2"),
                            DataCriacao = new DateTime(2024, 11, 4, 14, 46, 12, 590, DateTimeKind.Local).AddTicks(5493),
                            Endereco = "Rua dos Testes",
                            Nome = "Restaurante do Queres",
                            Site = "queres.com.br"
                        },
                        new
                        {
                            Id = new Guid("6dede088-4fa5-4a14-a6dd-0d2c5f83f3cc"),
                            DataCriacao = new DateTime(2024, 11, 7, 14, 46, 12, 590, DateTimeKind.Local).AddTicks(5496),
                            Endereco = "Rua dos Desenvolvedores",
                            Nome = "Restaurante dos Desenvolvedores",
                            Site = "desenvolvedores.com.br"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}