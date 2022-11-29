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
    public class BookLogic : IBookLogic
    {
        IRepository<Book> repo;



        public BookLogic(IRepository<Book> repo)
        {
            this.repo = repo;
        }

        public void Create(Book item)
        {
            if (item.Title.Length < 3)
            {
                throw new ArgumentException("The title is too short");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Book Read(int id)
        {
            return this.repo.Read(id);
        }
        public IQueryable<Book> ReadAll()
        {
            return this.repo.ReadAll();
        }
        public void Update(Book item)
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
