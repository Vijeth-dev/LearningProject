using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookMyRoomAPILayer.Models;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomCommonLayer.Entities;
using BookMyRoomCommonLayer.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMyRoomAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private IBusiness business;
        public ManagerController(IBusiness _business)
        {
            this.business = _business;
        }
        [HttpPost]
        public async Task<IActionResult> AddHotelManager(HotelManager hotelManager)
        {
            try
            {
                business.AddHotelManager(hotelManager);
            }
            catch (SQLException sqlException)
            {
                return BadRequest(new { message = sqlException.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
            return Ok();

        }
        [HttpPost("{hotelManagerEmail}")]
        
        public async Task<IActionResult> AddHotel(string hotelManagerEmail,[FromBody] HotelModel hotelModel)
        {
            try
            {
                SearchResult hotelValues=ModelMapper.ModelToEntity(hotelModel);
                bool flag=business.AddHotel(hotelValues,hotelModel.City,hotelManagerEmail);
                if(!flag)
                {
                    return Conflict(new { message= "This hotel already exists" });
                }
            }
            catch (SQLException sqlException)
            {
                return BadRequest(new { message = sqlException.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
            return Ok();
        }
        [HttpPut]

        public async Task<IActionResult> UpdateHotel([FromBody] HotelModel hotelModel)
        {
            try
            {
                SearchResult hotelValues = ModelMapper.ModelToEntity(hotelModel);
                bool flag = business.UpdateHotel(hotelValues);
                if (!flag)
                {
                    return Conflict(new { message = "This hotel already exists" });
                }
            }
            catch (SQLException sqlException)
            {
                return BadRequest(new { message = sqlException.Message });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetHotels(string hotelManagerEmail)
        {
            try
            {
                List<SearchResult> hotelList = business.FetchHotelsForManagers(hotelManagerEmail);
                Dictionary<int, List<SearchResult>> data = new Dictionary<int, List<SearchResult>>();
                List<SearchResult> searchResults = new List<SearchResult>();
                int index = 0;
                int counter = hotelList.Count();

                for (int i = 0; i < hotelList.Count(); i += 3)
                {

                    for (int j = i; j < i + 3; j++)
                    {
                        if (j == hotelList.Count())
                        {
                            break;
                        }
                        else
                        {
                            SearchResult searchResult = new SearchResult();
                            searchResult.AirportDistance = hotelList[j].AirportDistance;
                            searchResult.AirportName = hotelList[j].AirportName;
                            searchResult.CityName = hotelList[j].CityName;
                            searchResult.Hotel_Address = hotelList[j].Hotel_Address;
                            searchResult.Hotel_Email = hotelList[j].Hotel_Email;
                            searchResult.Hotel_Name = hotelList[j].Hotel_Name;
                            searchResult.Hotel_Phone = hotelList[j].Hotel_Phone;
                            searchResult.Hotel_Rating = hotelList[j].Hotel_Rating;
                            searchResult.Hotel_Status = hotelList[j].Hotel_Status;
                            searchResult.Parking = hotelList[j].Parking;
                            searchResult.Pictures = hotelList[j].Pictures;
                            searchResult.Pool = hotelList[j].Pool;
                            searchResult.RailwayDistance = hotelList[j].RailwayDistance;
                            searchResult.RailwayStationName = hotelList[j].RailwayStationName;
                            searchResult.Restaurant = hotelList[j].Restaurant;
                            searchResult.StateName = hotelList[j].StateName;
                            searchResult.Wifi = hotelList[j].Wifi;
                            searchResult.FeedBacks = hotelList[j].FeedBacks;
                            searchResults.Add(searchResult);
                        }
                    }
                    data.Add(index, searchResults);
                    index++;
                    searchResults = new List<SearchResult>();
                    //add and increase counter

                }
                return Ok(data);
            }
            catch (DataNotFound dataNotFound)
            {
                return BadRequest(new { message = dataNotFound.Message }); ;
            }
            catch (SQLException sqlException)
            {
                return BadRequest(new { message = sqlException.Message }); ;
            }
            catch (Exception exception)
            {
                return BadRequest(new { message = exception.Message }); ;
            }
            
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile([FromRoute] string id, [FromBody] HotelManagerlogin hotelManagerlogin)
        {
            HotelManagerlogin user = new HotelManagerlogin();
            try
            {

                user = ModelMapper.EntityToModelManager(business.UpdateProfile(id, ModelMapper.ModelToEntity_Update(hotelManagerlogin)));
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
                return BadRequest(new { message = "Oops! Something went wrong" });
            }
            return Ok(user);
            //}
        }
    }
}