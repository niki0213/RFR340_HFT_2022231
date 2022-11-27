using Microsoft.AspNetCore.Mvc;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        IPublisherLogic logic;

        public PublisherController(IPublisherLogic logic)
        {
            this.logic = logic;
        }
        // GET: api/<PublisherController>
        [HttpGet]
        public IEnumerable<Publisher> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public Publisher Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<PublisherController>
        [HttpPost]
        public void Create([FromBody] Publisher value)
        {
            Create(value);
        }

        // PUT api/<PublisherController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Publisher value)
        {
            logic.Update(value);
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
