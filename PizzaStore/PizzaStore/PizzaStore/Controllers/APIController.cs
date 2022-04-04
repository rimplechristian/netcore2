using Microsoft.AspNetCore.Mvc;
using PizzaStore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzaStore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly ProductContext _dbContext;
        public APIController(ProductContext DBContext)
        {

            _dbContext = DBContext;
        }

        

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<APIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet]
      [Route("GetProduct")]
        public List<products> GetProduct()
        {
            var obj = _dbContext.products.ToList();

               return obj;

        }
    }
}
