using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyRoomAPILayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookMyRoomAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        SearchModel model = new SearchModel();
        Dictionary<string, Dictionary<string, Dictionary<string, string>>> mycities = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();


        // GET api/values
        [HttpGet]
        public SearchModel Get()
        {
            model = new SearchModel()
            {
                Adult = 1,
                Children = 1,
                Infants = 1,
                City = "adsad",
                From = Convert.ToDateTime("12/12/12"),
                To = Convert.ToDateTime("12/12/12"),
                State = "sdasds"

            };
            return model;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }


        //POST api/values
       [HttpPost]
        public void Post([FromBody] SearchModel value)
        {
            this.model = value;
        }

        //[HttpPost]
        //public void Post([FromBody] string value)
        //{

        //}


        [HttpGet("{city}")]
        public Dictionary<string, Dictionary<string, string>> Post(string city)
        {
            Dictionary<string, Dictionary<string, string>> myCityHotel = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, string> hotelDetails = new Dictionary<string, string>();
            hotelDetails.Add("star","4");
            hotelDetails.Add("price", "10000");
            hotelDetails.Add("ac", "yes");
            myCityHotel.Add("MAYURA",hotelDetails);
            hotelDetails = new Dictionary<string, string>();
            hotelDetails.Add("star", "5");
            hotelDetails.Add("price", "20000");
            hotelDetails.Add("ac", "yes");
            myCityHotel.Add("KADAMBA",hotelDetails);
            mycities.Add("DELHI",myCityHotel);
            hotelDetails = new Dictionary<string, string>();
            hotelDetails.Add("star", "5");
            hotelDetails.Add("price", "20000");
            hotelDetails.Add("ac", "yes");
            myCityHotel = new Dictionary<string, Dictionary<string, string>>();
            myCityHotel.Add("KADAMBA", hotelDetails);
            mycities.Add("MYSORE", myCityHotel);
            foreach (KeyValuePair<string, Dictionary<string, Dictionary<string, string>>> hoteldetails in mycities)
            {
                if (hoteldetails.Key == city.ToUpper())
                {
                    return hoteldetails.Value;
                }
            }
            return null;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
