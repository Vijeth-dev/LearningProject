using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookMyRoomAPILayer.Models;
using BookMyRoomBusinessLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyRoomAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        IBusiness _business;
        public BookingController(IBusiness business)
        {
            _business = business;
        }

        [HttpGet("{id}")]
        public IActionResult GetRoomCost (int id)
        {
            List<RoomCostModel> roomCost;
            try
            {
                roomCost = ModelMapper.EntityToModel(_business.GetRoomCost(id));
            }
            catch(Exception)
            {
                return BadRequest("Something went wrong");
            }
            return Ok(roomCost);
        }

        [HttpPost]
        public IActionResult CheckRoomAvailability([FromBody] RoomAvailabilityModel roomAvailabilityModel)
        {
            dynamic roomAvailability;
            try
            {
                roomAvailability = _business.CheckRoomAvailability(ModelMapper.ModelToEntity(roomAvailabilityModel));
            }
            catch (Exception e)
            {
                return BadRequest("Rooms are not available");
            }
            return Ok(roomAvailability);
        }

        [HttpGet("bookings/{UserID}")]
        public IActionResult GetBookings(int UserID)
        {
            List<BookingModel> bookings;
            try
            {
                bookings = ModelMapper.EntityToModel(_business.GetBookings(UserID));
            }
            catch (SqlException sqlException)
            {
                return BadRequest(new { message = sqlException.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Oops Something went wrong" });
            }
            return Ok(bookings);
        }
    }
}
