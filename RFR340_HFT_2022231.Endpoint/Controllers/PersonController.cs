using Microsoft.AspNetCore.Mvc;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonLogic logic;

        public PersonController(IPersonLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public Person Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public void Create([FromBody] Person value)
        {
            this.logic.Create(value);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Person value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
