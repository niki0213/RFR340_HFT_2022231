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

        [HttpGet]
        public IEnumerable<BookReadCount> BookReadCounter()
        {
            return this.logic.BookReadCounter();
        }
        [HttpGet]
        public IEnumerable<BookInfo> HaveRead([FromQuery] int id)
        {
            return this.logic.HaveRead(id);
        }

        [HttpGet]
        public IEnumerable<NotReturned> DidNotReturned()
        {
            return this.logic.DidNotReturned();
        }

        [HttpGet]
        public IEnumerable<RentedIt> RentedBy([FromQuery] int id)
        {
            return this.logic.RentedBy(id);
        }
    }
}
