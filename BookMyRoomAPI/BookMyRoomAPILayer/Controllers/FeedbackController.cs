using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookMyRoomAPILayer.Models;
using BookMyRoomBusinessLayer.Interfaces;

namespace BookMyRoomAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private IBusiness business;
        public FeedbackController(IBusiness _business)
        {
            this.business = _business;
        }
        [HttpPost]
        public IActionResult Post([FromBody] FeedbackModel feedback)
        {
            business.AddUserFeedback(ModelMapper.ModelToEntity(feedback));
            return Ok();
        }
    }
}