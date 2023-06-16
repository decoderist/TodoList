﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoList.Persistence;

#nullable disable

namespace TodoList.Persistence.Migrations
{
    [DbContext(typeof(TodoListDbContext))]
    [Migration("20230616150731_SeedingTodoItem")]
    partial class SeedingTodoItem
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodoList.Domain.TodoItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)")
                        .HasColumnName("Tags");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f7cabd24-da8d-4ae6-92fb-87ba0ef5c298"),
                            Content = "Content1",
                            CreatedBy = "a58633c9-3c6a-4580-8ad1-0720b582094f",
                            CreatedDate = new DateTime(2023, 6, 16, 18, 37, 31, 890, DateTimeKind.Local).AddTicks(543),
                            Done = false,
                            DueDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tags = "Daily",
                            Title = "Title1"
                        },
                        new
                        {
                            Id = new Guid("446dbd7e-6564-43fb-82cc-eb2ba631736b"),
                            Content = "Content2",
                            CreatedBy = "a58633c9-3c6a-4580-8ad1-0720b582094f",
                            CreatedDate = new DateTime(2023, 6, 16, 18, 37, 31, 890, DateTimeKind.Local).AddTicks(586),
                            Done = true,
                            DueDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Tags = "Monthly",
                            Title = "Title2"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}