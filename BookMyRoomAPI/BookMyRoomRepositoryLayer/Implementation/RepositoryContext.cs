using BookMyRoomCommonLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyRoomRepositoryLayer.Implementation
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        
        public DbSet<HotelManager> HotelManagers { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Airports> Airports { get; set; }
        public DbSet<RailwayStation> RailwayStation { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Pictures> Pictures { get; set; }
        public DbSet<UserProfiles> UserProfiles { get; set; }
        public DbSet<HotelFeedback> Feedbacks { get; set; }
        public DbSet<BookingEntity> Booking { get; set; }
        public DbSet<RoomEntity> RoomTable { get; set; }
        public DbSet<RoomTypeEntity> RoomTypeTable { get; set; }
    }
}
