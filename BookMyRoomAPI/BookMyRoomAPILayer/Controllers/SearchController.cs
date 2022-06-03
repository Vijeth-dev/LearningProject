using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyRoomBusinessLayer.Interfaces;
using BookMyRoomCommonLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using BookMyRoomCommonLayer.Exceptions;
using Microsoft.AspNetCore.Authorization;
using BookMyRoomAPILayer.Models;

namespace BookMyRoomAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SearchController : ControllerBase
    {
        public static Search searchlist = new Search();

        private IBusiness business;
        public SearchController(IBusiness _business)
        {
            this.business = _business;
        }
        [HttpGet("{search}")]//search the city name 
        public async Task<IActionResult> Get(string search)
        {
            List<SearchResult> myList1;
            try
            {
                myList1 = await Task.Run(() => business.SearchHotel(search));
            }
            catch (DataNotFound dataNotFound)
            {
                return BadRequest(new { message = dataNotFound.Message });
            }
            catch (SQLException sqlException)
            {
                return BadRequest(new { message = sqlException.Message });
            }
            catch (Exception)
            {
                return BadRequest();
            }

            List<SearchResult> searchResults = new List<SearchResult>();
            Dictionary<int, List<SearchResult>> data = new Dictionary<int, List<SearchResult>>();
            int index = 0;
            int counter = myList1.Count();

            for (int i = 0; i < myList1.Count(); i += 3)
            {

                for (int j = i; j < i + 3; j++)
                {
                    if (j == myList1.Count())
                    {
                        break;
                    }
                    else
                    {
                        SearchResult searchResult = new SearchResult();
                        searchResult.AirportDistance = myList1[j].AirportDistance;
                        searchResult.AirportName = myList1[j].AirportName;
                        searchResult.CityName = myList1[j].CityName;
                        searchResult.Hotel_Id = myList1[j].Hotel_Id;
                        searchResult.Hotel_Address = myList1[j].Hotel_Address;
                        searchResult.Hotel_Email = myList1[j].Hotel_Email;
                        searchResult.Hotel_Name = myList1[j].Hotel_Name;
                        searchResult.Hotel_Phone = myList1[j].Hotel_Phone;
                        searchResult.Hotel_Rating = myList1[j].Hotel_Rating;
                        searchResult.Hotel_Status = myList1[j].Hotel_Status;
                        searchResult.Parking = myList1[j].Parking;
                        searchResult.Pictures = myList1[j].Pictures;
                        searchResult.Pool = myList1[j].Pool;
                        searchResult.RailwayDistance = myList1[j].RailwayDistance;
                        searchResult.RailwayStationName = myList1[j].RailwayStationName;
                        searchResult.Restaurant = myList1[j].Restaurant;
                        searchResult.StateName = myList1[j].StateName;
                        searchResult.Wifi = myList1[j].Wifi;
                        searchResult.FeedBacks = myList1[j].FeedBacks;
                        searchResults.Add(searchResult);
                    }
                }
                data.Add(index, searchResults);
                index++;
                searchResults = new List<SearchResult>();

            }

            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> GetDetails([FromBody] Search searchDetails)
        {
            searchlist = searchDetails;
            return Ok(searchlist);
        }
        [HttpGet]//get the hotel details depending upon the city
        public async Task<IActionResult> GetHotel()
        {
            string searchCity = searchlist.City;
            try
            {
                var list = await Task.Run(() => business.SearchHotel(searchCity));
            }
            catch (DataNotFound dataNotFound)
            {
                return BadRequest(new { message = dataNotFound.Message });
            }
            catch (SQLException sqlException)
            {
                return BadRequest(new { message = sqlException.Message });
            }
            catch (Exception)
            {
                return BadRequest();
            }
            dynamic list1;
            try
            {
                list1 = await Task.Run(() => business.SearchHotel(searchCity));
            }
            catch(DataNotFound)
            {
                return BadRequest("No Results found");
            }
            catch (SQLException sqlException)
            {
                return BadRequest(new { message = sqlException.Message });
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok(list1);
        }

        [HttpPost("{route}")]
        public IActionResult GetPerticularHotelDetail([FromRoute]string route , [FromBody] HotelAndCityNameModel searchHotel )
        {
            SearchResult particularHotel;
            try
            {
                particularHotel = business.GetParticularHotel(ModelMapper.ModelToEntity(searchHotel));
            }
            catch(SQLException)
            {
                return BadRequest();
            }
            catch(Exception)
            {
                return BadRequest();
            }
            return Ok(particularHotel);
        }

    }
}