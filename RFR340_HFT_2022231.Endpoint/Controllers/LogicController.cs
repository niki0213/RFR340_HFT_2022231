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
            return logic.BookReadCounter();
        }
        [HttpGet("{id}")]
        public IEnumerable<BookLogic.BookInfo> HaveRead(int ID)
        {
            return logic.HaveRead(ID);
        }
        [HttpGet]
        public IEnumerable<BookLogic.PublisherInfo> PublishedBooks()
        {
            return logic.PublishedBooks();
        }
        [HttpGet]
        public IEnumerable<BookLogic.NotReturned> DidNotReturned()
        {
            return logic.DidNotReturned();
        }
        [HttpGet("{id}")]
        public IEnumerable<BookLogic.RentedIt> RentedBy(int id)
        {
            return logic.RentedBy(id);
        }
    }
}
