﻿// <auto-generated />
using System;
using Backend_HF_1.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Backend_HF_1.Database.Migrations
{
    [DbContext(typeof(DunaLevelDbContext))]
    [Migration("20241117153355_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Backend_HF_1.Models.DunaLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "date");

                    b.Property<int>("WaterLevel")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "value");

                    b.HasKey("Id");

                    b.ToTable("WaterLevels");
                });

            modelBuilder.Entity("Backend_HF_1.Models.MonthlyStatistics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AverageValue")
                        .HasColumnType("float")
                        .HasAnnotation("Relational:JsonPropertyName", "average_value");

                    b.Property<int>("MaximalValue")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "maximal_value");

                    b.Property<int>("MinimalValue")
                        .HasColumnType("int")
                        .HasAnnotation("Relational:JsonPropertyName", "minimal_value");

                    b.Property<string>("Month")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MonthlyStatistics");
                });
#pragma warning restore 612, 618
        }
    }
}
