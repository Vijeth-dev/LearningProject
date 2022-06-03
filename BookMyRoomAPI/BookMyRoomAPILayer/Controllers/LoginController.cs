using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookMyRoomAPILayer.Models;
using Microsoft.AspNetCore.Authorization;
using BookMyRoomBusinessLayer.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using BookMyRoomCommonLayer.Entities;
using BookMyRoomCommonLayer.Exceptions;

namespace BookMyRoomAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private IBusiness business;

        public LoginController(IBusiness _business)
        {
            this.business = _business;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] UserLoginModel userLogin)
        {
            UserModel user;
            HotelManagerlogin hotelManagerLogin;
            if (!ModelState.IsValid)
            {
                return Unauthorized();
            }
            else
            {
                if (userLogin.Designation == "User")
                {
                    try
                    {
                        user = ModelMapper.EntityToModel(business.AuthenticateUser(ModelMapper.ModelToEntity(userLogin)));
                    }
                    catch (InvalidUserException)
                    {
                        return Unauthorized();
                    }

                    user.Token = GenerateToken(user.Email);
                    return Ok(user);
                }
                else
                {
                    hotelManagerLogin = new HotelManagerlogin();
                    HotelManager hotelManager;
                    try
                    {
                        hotelManager = business.AuthenticateUser(ModelMapper.ModelToEntity(userLogin));
                    }
                    catch (InvalidUserException)
                    {
                        return Unauthorized();
                    }
                    hotelManager.HotelManager_ID = hotelManager.HotelManager_ID;
                    hotelManagerLogin.FirstName = hotelManager.HotelManager_Name;
                    hotelManagerLogin.Email = hotelManager._EmailID;
                    hotelManagerLogin.UserType = hotelManager._Designation;
                    hotelManagerLogin.PhoneNo = hotelManager.HotelManager_PhoneNumber;
                    hotelManagerLogin.Token = GenerateToken(hotelManager._EmailID);
                    return Ok(hotelManagerLogin);
                }
            }
        }

        private string GenerateToken(string userEmail)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes("shhecret passcode");
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userEmail)
                }),
                Expires = DateTime.Now.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}