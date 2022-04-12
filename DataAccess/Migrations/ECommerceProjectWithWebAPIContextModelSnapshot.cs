﻿// <auto-generated />
using System;
using DataAccess.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(ECommerceProjectWithWebAPIContext))]
    partial class ECommerceProjectWithWebAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(5828));

                    b.Property<int>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("Gender")
                        .HasColumnType("bit")
                        .HasColumnName("Gender");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Password");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users", "@dbo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "İstanbul/Pendik",
                            CreatedDate = new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(6867),
                            CreatedUserId = 1,
                            DateOfBirth = new DateTime(2000, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "furkanaltintas785@gmail.com",
                            FirstName = "Furkan",
                            Gender = true,
                            LastName = "Altıntaş",
                            Password = "12345",
                            UpdatedDate = new DateTime(2022, 4, 12, 0, 54, 29, 711, DateTimeKind.Local).AddTicks(6875),
                            UpdatedUserId = 1,
                            UserName = "furkanaltintas"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
