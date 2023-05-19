﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using RFR340_HFT_2022231.Endpoint.Sevices;
using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RFR340_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonLogic logic;
        IHubContext<SignalRHub> hub;
        public PersonController(IPersonLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Person> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Person Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Person value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("PersonCreated", value);
        }

        [HttpPut]
        public void Update([FromBody] Person value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("PersonUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("PersonDeleted", ToDelete);
        }
    }
}
