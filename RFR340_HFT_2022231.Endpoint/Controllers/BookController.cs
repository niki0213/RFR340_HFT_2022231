using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RFR340_HFT_2022231.Endpoint.Sevices;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models;
using System.Collections.Generic;



namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookLogic logic;
        IHubContext<SignalRHub> hub;
        public BookController(IBookLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Book> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Book Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Book value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("BookCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Book value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("BookUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var bookToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("BookDeleted", bookToDelete);
        }
    }
}
