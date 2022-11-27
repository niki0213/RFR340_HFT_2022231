using Microsoft.AspNetCore.Mvc;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models;
using static RFR340_HFT_2022231.Logic.BookLogic;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogicController : ControllerBase
    {
        IBookLogic logic;

        public LogicController(IBookLogic logic)
        {
            this.logic = logic;
        }
        public Books Read(int id)
        {
            return this.logic.Read(id);
        }

        public IEnumerable<BookReadCount> BookReadCounter()
        {
            return this.logic.BookReadCounter();
        }
        public IEnumerable<BookInfo> HaveRead(int ID)
        {
            return this.logic.HaveRead(ID);
        }
        public IEnumerable<PublisherInfo> PublishedBooks()
        {
            return this.logic.PublishedBooks();
        }
        public IEnumerable<NotReturned> DidNotReturned()
        {
            return this.logic.DidNotReturned();
        }
        public IEnumerable<RentedIt> RentedBy(int bookid)
        {
            return this.logic.RentedBy(bookid);
        }

    }
}
