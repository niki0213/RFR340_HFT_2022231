using Microsoft.AspNetCore.Mvc;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models.DTO;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MethodController : ControllerBase
    {
        IRentLogic rentlogic;
        IBookLogic booklogic;

        public MethodController(IRentLogic rentLogic, IBookLogic booklogic)
        {
            this.rentlogic = rentLogic;
            this.booklogic = booklogic;
        }

        [HttpGet]
        public IEnumerable<BookReadCount> BookReadCounter()
        {
            return this.rentlogic.BookReadCounter();
        }
        [HttpGet]
        public IEnumerable<BookInfo> HaveRead([FromQuery] int id)
        {
            return this.rentlogic.HaveRead(id);
        }

        [HttpGet]
        public IEnumerable<NotReturned> DidNotReturned()
        {
            return this.rentlogic.DidNotReturned();
        }

        [HttpGet]
        public IEnumerable<RentedIt> RentedBy([FromQuery] int id)
        {
            return this.rentlogic.RentedBy(id);
        }
        [HttpGet]
        public IEnumerable<PublisherInfo> PublishedBooks()
        {
            return this.booklogic.PublishedBooks();
        }
    }
}
