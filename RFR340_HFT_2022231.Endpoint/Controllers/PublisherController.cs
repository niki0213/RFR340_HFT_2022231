using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RFR340_HFT_2022231.Endpoint.Sevices;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        IPublisherLogic logic;
        IHubContext<SignalRHub> hub;
        public PublisherController(IPublisherLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Publisher> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Publisher Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Publisher value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("PublisherCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Publisher value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("PublisherUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("PublisherDeleted", ToDelete);
        }
    }
}
