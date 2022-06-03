﻿// <auto-generated />
using System;
using BookMyRoomRepositoryLayer.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookMyRoomRepositoryLayer.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20190903041439_BookMyRoomMigration")]
    partial class BookMyRoomMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.Airports", b =>
                {
                    b.Property<int>("AirportID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AirportName")
                        .IsRequired();

                    b.Property<int>("CityID");

                    b.HasKey("AirportID");

                    b.HasIndex("CityID");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .IsRequired();

                    b.Property<int>("StateID1");

                    b.HasKey("CityID");

                    b.HasIndex("StateID1");

                    b.ToTable("City");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.Hotel", b =>
                {
                    b.Property<int>("HotelID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AirportDistance");

                    b.Property<int?>("Airports");

                    b.Property<int?>("City")
                        .IsRequired();

                    b.Property<int?>("HotelManager")
                        .IsRequired();

                    b.Property<string>("Hotel_Address")
                        .IsRequired();

                    b.Property<string>("Hotel_EmailID")
                        .IsRequired();

                    b.Property<string>("Hotel_Name")
                        .IsRequired();

                    b.Property<string>("Hotel_PhoneNumber")
                        .IsRequired();

                    b.Property<float>("Hotel_Rating");

                    b.Property<string>("Hotel_Status")
                        .IsRequired();

                    b.Property<bool>("Parking");

                    b.Property<bool>("Pool");

                    b.Property<double>("RailwayDistance");

                    b.Property<int?>("RailwayStation");

                    b.Property<bool>("Restaurant");

                    b.Property<bool>("Wifi");

                    b.HasKey("HotelID");

                    b.HasIndex("Airports");

                    b.HasIndex("City");

                    b.HasIndex("HotelManager");

                    b.HasIndex("RailwayStation");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.HotelFeedback", b =>
                {
                    b.Property<int>("FeedbackID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Feedback");

                    b.Property<int?>("Hotel");

                    b.HasKey("FeedbackID");

                    b.HasIndex("Hotel");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.HotelManager", b =>
                {
                    b.Property<int>("HotelManager_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HotelManager_Name")
                        .IsRequired();

                    b.Property<string>("HotelManager_PhoneNumber")
                        .IsRequired();

                    b.Property<string>("_Designation")
                        .IsRequired();

                    b.Property<string>("_EmailID")
                        .IsRequired();

                    b.Property<string>("_Password")
                        .IsRequired();

                    b.Property<string>("_Status")
                        .IsRequired();

                    b.HasKey("HotelManager_ID");

                    b.ToTable("HotelManager");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.Pictures", b =>
                {
                    b.Property<int>("PicturesID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Hotel");

                    b.Property<int?>("HotelsHotelID");

                    b.Property<string>("Picture");

                    b.HasKey("PicturesID");

                    b.HasIndex("HotelsHotelID");

                    b.ToTable("Pictures");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.RailwayStation", b =>
                {
                    b.Property<int>("RailwayStationID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID");

                    b.Property<string>("RailwayStationName")
                        .IsRequired();

                    b.HasKey("RailwayStationID");

                    b.HasIndex("CityID");

                    b.ToTable("RailwayStation");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.State", b =>
                {
                    b.Property<int>("StateID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StateName")
                        .IsRequired();

                    b.HasKey("StateID");

                    b.ToTable("State");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.UserProfiles", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("User_EmailID")
                        .IsRequired();

                    b.Property<string>("User_FirstName")
                        .IsRequired();

                    b.Property<string>("User_Lastname")
                        .IsRequired();

                    b.Property<string>("User_Password")
                        .IsRequired();

                    b.Property<string>("User_PhoneNumber")
                        .IsRequired();

                    b.HasKey("User_ID");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.Airports", b =>
                {
                    b.HasOne("BookMyRoomCommonLayer.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.City", b =>
                {
                    b.HasOne("BookMyRoomCommonLayer.Entities.State", "StateID")
                        .WithMany()
                        .HasForeignKey("StateID1")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.Hotel", b =>
                {
                    b.HasOne("BookMyRoomCommonLayer.Entities.Airports", "AirportID")
                        .WithMany()
                        .HasForeignKey("Airports");

                    b.HasOne("BookMyRoomCommonLayer.Entities.City", "CityID")
                        .WithMany()
                        .HasForeignKey("City")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookMyRoomCommonLayer.Entities.HotelManager", "HotelManagerID")
                        .WithMany()
                        .HasForeignKey("HotelManager")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookMyRoomCommonLayer.Entities.RailwayStation", "RailwayStationID")
                        .WithMany()
                        .HasForeignKey("RailwayStation");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.HotelFeedback", b =>
                {
                    b.HasOne("BookMyRoomCommonLayer.Entities.Hotel", "HotelID")
                        .WithMany()
                        .HasForeignKey("Hotel");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.Pictures", b =>
                {
                    b.HasOne("BookMyRoomCommonLayer.Entities.Hotel", "Hotels")
                        .WithMany()
                        .HasForeignKey("HotelsHotelID");
                });

            modelBuilder.Entity("BookMyRoomCommonLayer.Entities.RailwayStation", b =>
                {
                    b.HasOne("BookMyRoomCommonLayer.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
