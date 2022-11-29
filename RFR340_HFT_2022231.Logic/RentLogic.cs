using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Models.DTO;
using RFR340_HFT_2022231.Repository;

namespace RFR340_HFT_2022231.Logic
{
    public class RentLogic: IRentLogic
    {
        public IRepository<Rent> repo;

        public RentLogic(IRepository<Rent> repo)
        {
            this.repo = repo;
        }

        public void Create(Rent item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Rent Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Rent> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Rent item)
        {
            this.repo.Update(item);
        }
        public IEnumerable<BookReadCount> BookReadCounter()
        {
            return from x in repo.ReadAll()
                   group x by x.BookID into y
                   select new BookReadCount()
                   {
                       Id = y.Key,
                       Count = y.Count()
                   };

        }
        public IEnumerable<BookInfo> HaveRead(int ID)
        {
            return from x in this.repo.ReadAll()
                   where x.PersonID == ID
                   select new BookInfo()
                   {
                       ID = x.BookID,
                       Title = x.Book.Title
                   };

        }
        public IEnumerable<NotReturned> DidNotReturned()
        {
            return from r in this.repo.ReadAll()
                   where r.Back == false
                   select new NotReturned()
                   {
                       BID = r.BookID,
                       Title = r.Book.Title,
                       PID = r.PersonID,
                       Name = r.Person.Name,
                       PhoneNumber = r.Person.Phone
                   };

        }
        public IEnumerable<RentedIt> RentedBy(int bookid)
        {
            return from r in repo.ReadAll()
                   where r.BookID == bookid
                   select new RentedIt()
                   {
                       ID = r.Person.PersonID,
                       Name = r.Person.Name,
 

                   };
        }

    }
}
