using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Models.DTO;
using RFR340_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Logic
{
    public class PublisherLogic: IPublisherLogic
    {
        IRepository<Publisher> repo;

        public PublisherLogic(IRepository<Publisher> repo)
        {
            this.repo = repo;
        }

        public void Create(Publisher item)
        {
            if (item.Name.Length < 5)
            {
                throw new ArgumentException("The name is too short");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Publisher Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Publisher> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Publisher item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<PublisherInfo> PublishedBooks()
        {
            return from b in this.repo.ReadAll()
                   group b by b.PublisherID into g

                   select new PublisherInfo()
                   {
                       ID = g.Key,
                       BookCount = g.Count(),
                   };
        }
    }
}
