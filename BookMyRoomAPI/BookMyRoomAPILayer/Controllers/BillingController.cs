using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyRoomAPILayer.Models;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomCommonLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyRoomAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {

        private IBusiness business;
        public BillingController(IBusiness _business)
        {
            this.business = _business;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult AddBooking([FromBody] BookingModel bookingEntityModel)
        {
            try
            {
                bookingEntityModel = ModelMapper.EntityToModel(business.BookHotel(ModelMapper.ModelToEntity(bookingEntityModel)));
                return Ok(bookingEntityModel);
            }
            catch (RoomNotavailable e)
            {
                return BadRequest(e);
            }
            catch (Exception)
            {
                return BadRequest("OOps something went wrong!!!!");
            }
        }
    }
}