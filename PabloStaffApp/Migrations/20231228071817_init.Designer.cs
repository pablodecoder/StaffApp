﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PabloStaffApp.Data;

#nullable disable

namespace PabloStaffApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231228071817_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PabloStaffApp.Models.EmployeeEntity", b =>
                {
                    b.Property<int>("EmpId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmpId"));

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmpId");

                    b.ToTable("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}