using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace RFR340_HFT_2022231.Logic
{
    public interface IPublisherLogic
    {
        void Create(Publisher item);
        void Delete(int id);
        Publisher Read(int id);
        IQueryable<Publisher> ReadAll();
        void Update(Publisher item);
    }
}