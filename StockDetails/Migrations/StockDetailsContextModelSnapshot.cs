﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockDetails.Models;

#nullable disable

namespace StockDetails.Migrations
{
    [DbContext(typeof(StockDetailsContext))]
    partial class StockDetailsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockDetails.Models.DailyStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("High")
                        .HasColumnType("float");

                    b.Property<double>("Low")
                        .HasColumnType("float");

                    b.Property<int>("StockDataStockID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockDataStockID");

                    b.ToTable("DailyStocks");
                });

            modelBuilder.Entity("StockDetails.Models.StockData", b =>
                {
                    b.Property<int>("StockID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StockID"), 1L, 1);

                    b.Property<int>("CompanyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("TodayHigh")
                        .HasColumnType("float");

                    b.Property<double>("TodayLow")
                        .HasColumnType("float");

                    b.Property<double>("YearHigh")
                        .HasColumnType("float");

                    b.Property<double>("YearLow")
                        .HasColumnType("float");

                    b.HasKey("StockID");

                    b.ToTable("StockDetails");
                });

            modelBuilder.Entity("StockDetails.Models.DailyStock", b =>
                {
                    b.HasOne("StockDetails.Models.StockData", null)
                        .WithMany("DailyStocks")
                        .HasForeignKey("StockDataStockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StockDetails.Models.StockData", b =>
                {
                    b.Navigation("DailyStocks");
                });
#pragma warning restore 612, 618
        }
    }
}
