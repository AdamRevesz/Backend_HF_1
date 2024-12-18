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
    [Migration("20241118184139_Fasz123")]
    partial class Fasz123
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
#pragma warning restore 612, 618
        }
    }
}
