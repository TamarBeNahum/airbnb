using airbnb.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace airbnb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        // GET: api/<FlatsController>
        [HttpGet]
        public IEnumerable<Flat> Get()
        {
            return Flat.Read();
        }

        //Return all apartments whose price is cheaper than the parameter given to it
        //Use QueryStrin
        [HttpGet]
        [Route("GetByPrice")]
        public IEnumerable<Flat> GetByPrice(double price)
        {
            return Flat.GetByPrice(price);
        }

        //Return all the apartments located in a certain city that are rated above or equal to a parameter rating
        //Use Resource routing
        [HttpGet]
        [Route("GetCR/City/{city}/Rating/{reviewScore}")]
        public IEnumerable<Flat> GetByCityRating(string city, float reviewScore)
        {
            return Flat.GetByCityRating(city, reviewScore);
        }

        // GET api/<FlatsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlatsController>
        [HttpPost]
        public bool Post([FromBody] Flat f)
        {
            return f.Insert();
        }

        // PUT api/<FlatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlatsController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return Flat.DeleteById(id);
        }
    }
}
