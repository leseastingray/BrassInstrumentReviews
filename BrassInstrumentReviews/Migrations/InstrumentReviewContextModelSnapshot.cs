﻿// <auto-generated />
using System;
using BrassInstrumentReviews.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BrassInstrumentReviews.Migrations
{
    [DbContext(typeof(InstrumentReviewContext))]
    partial class InstrumentReviewContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("BrassInstrumentReviews.Models.Instrument", b =>
                {
                    b.Property<int>("InstrumentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstrumentID");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("BrassInstrumentReviews.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("InstrumentName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("InstrumentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReviewText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReviewerName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("ReviewID");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            ReviewID = 1,
                            InstrumentName = "Reynolds Contempora bass trombone",
                            InstrumentType = "Trombone",
                            Rating = 3,
                            ReviewDate = new DateTime(2020, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReviewerName = "stingray"
                        },
                        new
                        {
                            ReviewID = 2,
                            InstrumentName = "Bach Stradivarius Bb trumpet",
                            InstrumentType = "Trumpet",
                            Rating = 4,
                            ReviewDate = new DateTime(2020, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReviewerName = "Spot"
                        },
                        new
                        {
                            ReviewID = 3,
                            InstrumentName = "Conn 8D horn",
                            InstrumentType = "French horn",
                            Rating = 5,
                            ReviewDate = new DateTime(2020, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ReviewerName = "Megan cat"
                        });
                });

            modelBuilder.Entity("BrassInstrumentReviews.Models.Reviewer", b =>
                {
                    b.Property<int>("ReviewerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("PrimaryInstrument")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReviewerID");

                    b.ToTable("Reviewers");
                });
#pragma warning restore 612, 618
        }
    }
}
