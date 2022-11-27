using Microsoft.AspNetCore.Mvc;
using RFR340_HFT_2022231.Logic;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class LogicController : ControllerBase
    {
        IBookLogic logic;

        public LogicController(IBookLogic logic)
        {
            this.logic = logic;
        }
        [HttpGet]
        public IEnumerable<BookLogic.BookReadCount> BookReadCounter()
        {
            return this.logic.BookReadCounter();
        }
        [HttpGet("{id}")]
        public IEnumerable<BookLogic.BookInfo> HaveRead(int ID)
        {
            return this.logic.HaveRead(ID);
        }
        [HttpGet]
        public IEnumerable<BookLogic.PublisherInfo> PublishedBooks()
        {
            return this.logic.PublishedBooks();
        }
        [HttpGet]
        public IEnumerable<BookLogic.NotReturned> DidNotReturned()
        {
            return this.logic.DidNotReturned();
        }
        [HttpGet("{id}")]
        public IEnumerable<BookLogic.RentedIt> RentedBy(int id)
        {
            return this.logic.RentedBy(id);
        }
    }
}
