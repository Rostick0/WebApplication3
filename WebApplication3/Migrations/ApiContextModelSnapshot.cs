﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication3.Data;

#nullable disable

namespace WebApplication3.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication3.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Color = "#fec106",
                            Title = "Продукты",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 2,
                            Color = "#fef277",
                            Title = "Кафе",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 3,
                            Color = "#1d5e1f",
                            Title = "Образование",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 4,
                            Color = "#e53937",
                            Title = "Транспорт",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 5,
                            Color = "#b49fdb",
                            Title = "Дом",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 6,
                            Color = "#81deec",
                            Title = "Досуг",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 7,
                            Color = "#f68eb1",
                            Title = "Подарки",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 8,
                            Color = "#f15450",
                            Title = "Здоровье",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 9,
                            Color = "#01acc2",
                            Title = "Одежда",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 10,
                            Color = "#5f34b0",
                            Title = "Другое",
                            Type = "Expenses"
                        },
                        new
                        {
                            Id = 11,
                            Color = "#9ccd63",
                            Title = "Зарплата",
                            Type = "Income"
                        },
                        new
                        {
                            Id = 12,
                            Color = "#ffec3c",
                            Title = "Инвестции",
                            Type = "Income"
                        },
                        new
                        {
                            Id = 13,
                            Color = "#03897c",
                            Title = "Бизнес",
                            Type = "Income"
                        },
                        new
                        {
                            Id = 14,
                            Color = "#0499e7",
                            Title = "Процент по вкладу",
                            Type = "Income"
                        },
                        new
                        {
                            Id = 15,
                            Color = "#f06292",
                            Title = "Другое",
                            Type = "Income"
                        });
                });

            modelBuilder.Entity("WebApplication3.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("WebApplication3.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Sum")
                        .HasColumnType("real");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Todos");
                });

            modelBuilder.Entity("WebApplication3.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication3.Models.Image", b =>
                {
                    b.HasOne("WebApplication3.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication3.Models.Todo", b =>
                {
                    b.HasOne("WebApplication3.Models.Category", "Category")
                        .WithMany("Todos")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication3.Models.User", "User")
                        .WithMany("Todos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebApplication3.Models.Category", b =>
                {
                    b.Navigation("Todos");
                });

            modelBuilder.Entity("WebApplication3.Models.User", b =>
                {
                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
