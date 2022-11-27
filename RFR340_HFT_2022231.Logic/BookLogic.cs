﻿using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Logic
{
    public class BookLogic: IBookLogic
    {
        IRepository<Books> repo;
        IRepository<Rent> rentrepo;
        IRepository<Person> personrepo;
        IRepository<Publisher> publisherrepo;

        public BookLogic(IRepository<Books> repo)
        {
            this.repo = repo;
        }

        public void Create(Books item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Books Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Books> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Books item)
        {
            this.repo.Update(item);
        }

        public IEnumerable<BookReadCount> BookReadCounter()
        {
            return from x in this.rentrepo.ReadAll()
                   group x by x.BookID into g
                   join y in repo.ReadAll()
                   on g.Key equals y.BookID
                   select new BookReadCount()
                   {
                       Id = g.Key,
                       Title = y.Title,
                       Count = g.Count()
                   };

        }
        public class BookReadCount
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int Count { get; set; }
        }

        public IEnumerable<BookInfo> HaveRead(int ID)
        {
            return from x in this.rentrepo.ReadAll()
                   join b in this.repo.ReadAll()
                   on x.BookID equals b.BookID
                   where x.PersonID==ID
                   select new BookInfo()
                   {
                       ID = x.BookID,
                       Title = b.Title
                   };
        }
        public class BookInfo
        {
            public int ID { get; set; }
            public string Title {  get; set;}
        }

        public IEnumerable<PublisherInfo> PublishedBooks()
        {
            return from b in this.repo.ReadAll()
                   group b by b.PublisherID into g
                   join p in this.publisherrepo.ReadAll()
                   on g.Key equals p.PublisherID
                   select new PublisherInfo()
                   {
                       ID = g.Key,
                       Name = p.Name,
                       BookCount = g.Count()
                   };
        }
        public class PublisherInfo
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int BookCount { get; set; }
        }
        public IEnumerable<NotReturned> DidNotReturned()
        {
            var g = from p in this.personrepo.ReadAll()
                    join r in this.rentrepo.ReadAll()
                    on p.PersonID equals r.PersonID
                    where r.End.Year==0
                    select new
                    {
                        p.PersonID,
                        p.FirstName, 
                        p.LastName,
                        p.phone,
                        r.BookID
                    };

            return from p in g
                   join b in this.repo.ReadAll()
                   on p.BookID equals b.BookID
                   select new NotReturned()
                   {
                       BID = b.BookID,
                       Title = b.Title,
                       PID = p.PersonID,
                       FirstName = p.FirstName,
                       LastName= p.LastName,
                       PhoneNumber = p.phone
                   };
        }

        public class NotReturned
        {
            public int BID { get; set; }
            public string Title { get; set; }
            public int PID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }
        }

        public IEnumerable<RentedIt> RentedBy(int bookid)
        {
             return from r in this.rentrepo.ReadAll()
                    join p in this.personrepo.ReadAll()
                    on r.PersonID equals p.PersonID
                    where r.BookID==bookid
                    select new RentedIt()
                    {
                        ID= p.PersonID,
                        FirstName = p.FirstName,
                        LastName= p.LastName,
                        PhoneNumber= p.phone

                    };

          
        }

        public class RentedIt
        {

            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string PhoneNumber { get; set; }

        }


    }
    
}