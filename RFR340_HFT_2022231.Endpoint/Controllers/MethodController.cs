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
        IRentLogic logic;

        public MethodController(IRentLogic logic)
        {
            this.logic = logic;
        }

        //[HttpGet]
        //public IEnumerable<BookReadCount> BookReadCounter()
        //{
        //    return this.logic.BookReadCounter();
        //}
        //[HttpGet("{id}")]
        //public IEnumerable<BookInfo> HaveRead(int ID)
        //{
        //    return this.logic.HaveRead(ID);
        //}

        //[HttpGet]
        //public IEnumerable<PublisherInfo> PublishedBooks()
        //{
        //    return this.logic.PublishedBooks();
        //}

        //[HttpGet]
        //public IEnumerable<NotReturned> DidNotReturned()
        //{
        //    return this.logic.DidNotReturned();
        //}

        //[ HttpGet("{id}")]
        //public IEnumerable<RentedIt> RentedBy(int bookid)
        //{
        //    return this.logic.RentedBy(bookid);
        //}
    }
}
