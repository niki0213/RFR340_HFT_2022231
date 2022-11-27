using Microsoft.AspNetCore.Mvc;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        IRentLogic logic;

        public RentController(IRentLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<RentController>
        [HttpGet]
        public IEnumerable<Rent> ReadAll()
        {
            return logic.ReadAll();
        }

        // GET api/<RentController>/5
        [HttpGet("{id}")]
        public Rent Read(int id)
        {
            return logic.Read(id);
        }

        // POST api/<RentController>
        [HttpPost]
        public void Create([FromBody] Rent value)
        {
            logic.Create(value);
        }

        // PUT api/<RentController>/5
        [HttpPut("{id}")]
        public void Update([FromBody] Rent value)
        {
            logic.Update(value);
        }

        // DELETE api/<RentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            logic.Delete(id);
        }
    }
}
