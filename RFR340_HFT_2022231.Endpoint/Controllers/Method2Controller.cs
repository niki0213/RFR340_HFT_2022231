using Microsoft.AspNetCore.Mvc;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models.DTO;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class Method2Controller : ControllerBase
    {
        IBookLogic logic;

        public Method2Controller(IBookLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<PublisherInfo> PublishedBooks()
        {
            return this.logic.PublishedBooks();
        }
    }
}
