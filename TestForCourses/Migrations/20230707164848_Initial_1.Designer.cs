﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestForCourses.Data;

#nullable disable

namespace TestForCourses.Migrations
{
    [DbContext(typeof(CatalogDBContext))]
    [Migration("20230707164848_Initial_1")]
    partial class Initial_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.5.23280.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestForCourses.Data.Models.Catalog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Catalogs", (string)null);
                });

            modelBuilder.Entity("TestForCourses.Data.Models.Path", b =>
                {
                    b.Property<int>("AncestorId")
                        .HasColumnType("int");

                    b.Property<int>("Depth")
                        .HasColumnType("int");

                    b.Property<int>("DescendantId")
                        .HasColumnType("int");

                    b.ToTable("Paths");
                });
#pragma warning restore 612, 618
        }
    }
}