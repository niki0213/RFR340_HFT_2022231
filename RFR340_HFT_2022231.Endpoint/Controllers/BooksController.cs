using Microsoft.AspNetCore.Mvc;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models;
using System.Collections.Generic;
using static RFR340_HFT_2022231.Logic.BookLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBookLogic logic;

        public BooksController(IBookLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Books> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public Books Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Create([FromBody] Books value)
        {
            this.logic.Create(value);
        }

        // PUT api/<BooksController>/5
        [HttpPut]
        public void Update([FromBody] Books value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id); 
        }


    }
}
