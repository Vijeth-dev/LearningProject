using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomAPILayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;
using BookMyRoomCommonLayer.Exceptions;
using System.Net;
using Newtonsoft.Json.Linq;

namespace BookMyRoomAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterController : ControllerBase
    {
        private IBusiness business;

        public RegisterController(IBusiness _business)
        {
            this.business = _business;
        }
        /// <summary>
        /// Register with Google users
        /// </summary>
        /// <param name="userRegisterModel"></param>
        /// <returns></returns>
        [HttpPost("{route}")]
        public IActionResult RegisterGoogleOAuthUsers([FromRoute]string route, [FromBody] GoogleRegisterModel userRegisterModel)
        {
            var response = business.AuthorizeGoogleUser(userRegisterModel.Token,ModelMapper.ModelToEntity(userRegisterModel));
            if (response)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Registration for normal users
        /// </summary>
        /// <param name="userRegisterModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> RegisterNormalUsers([FromBody] UserModel userRegisterModel)
        {
            try
            {
                if (business.AddUserProfile(ModelMapper.ModelToEntity(userRegisterModel)))
                {
                    return Ok();
                }
                else
                {
                    return Conflict();
                }
                
            }
            catch (SqlException sqlException)
            {
                return BadRequest(new { message = sqlException.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile([FromRoute] string id, [FromBody] UserModel userRegisterModel)
        {
            UserModel user = new UserModel();
            try
            {

                user = ModelMapper.EntityToModel(business.UpdateProfile(id, ModelMapper.ModelToEntity_Update(userRegisterModel)));
            }
            catch (IncorrectCurrentPassword exception)
            {
                return BadRequest(new { message = exception.Message });
            }
            catch (SqlException sqlException)
            {
                return BadRequest(new { message = sqlException.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "OOps Something went wrong" });
            }
            return Ok(user);
            //}
        }
    }
}
