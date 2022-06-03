using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyRoomAPILayer.Models;
using BookMyRoomBusinessLayer.Implementation;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomCommonLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyRoomAPILayer.Controllers
{
    
    [ApiController]
    public class AdminController : ControllerBase
    {
        private IBusiness _business;

        public AdminController(IBusiness business)
        {
            this._business = business;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetManagerDetails()
        {

            List<HotelFetch> hotelManagers =_business.GetHotelManagers();
            //List<HotelManagerModel> hotelManagerModels = new List<HotelManagerModel>();
            //foreach(var a in hotelManagers)
            //{
            //    HotelManagerModel temp = ModelMapper.ManagerEntityToModel(a);
            //    hotelManagerModels.Add(temp);
            //}
            return Ok(hotelManagers);
        }

        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public ActionResult FetchHotels(int id)
        {
          return Ok(  _business.FetchHotels(id));
        }

        [HttpPut("{id}")]
        [Route("api/[controller]/manager/{id}")]

        public ActionResult ChangeManagerStatus(int id, [FromBody] string status)
        {
            _business.ChangeManagerStatus(id, status);
            return Ok();
        }

        [HttpPut("{id}")]
        [Route("api/[controller]/hotel/{id}")]

        public ActionResult ChangeHotelStatus(int id,[FromBody]string status)
        {
            _business.ChangeHotelStatus(id, status);
            return Ok();
        }



    }
}