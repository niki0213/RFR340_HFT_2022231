using RFR340_HFT_2022231.Models;
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
        IRepository<Rent> rentrepo;
        IRepository<Publisher> publisherrepo;
        IRepository<Person> personrepo;

        public BookLogic(IRepository<Book> repo, IRepository<Rent> rentrepo, IRepository<Publisher> publisherrepo, IRepository<Person> personrepo)
        {
            this.repo = repo;
            this.rentrepo = rentrepo;
            this.publisherrepo = publisherrepo;
            this.personrepo = personrepo;
        }

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

        public IEnumerable<BookReadCount> BookReadCounter()
        {
            return from x in rentrepo.ReadAll()
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
            public override bool Equals(object obj)
            {
                BookReadCount b = obj as BookReadCount;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Id == b.Id
                        && this.Title == b.Title
                        && this.Count == b.Count;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Id, this.Title, this.Count);
            }
        }

        public IEnumerable<BookInfo> HaveRead(int ID)
        {
            return from x in rentrepo.ReadAll()
                   join b in this.repo.ReadAll()
                   on x.BookID equals b.BookID
                   where x.PersonID == ID
                   select new BookInfo()
                   {
                       ID = x.BookID,
                       Title = b.Title
                   };

        }
        public class BookInfo
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public override bool Equals(object obj)
            {
                BookInfo b = obj as BookInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.ID == b.ID
                        && this.Title == b.Title;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.ID, this.Title);
            }
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
            public override bool Equals(object obj)
            {
                PublisherInfo b = obj as PublisherInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.ID == b.ID
                        && this.Name == b.Name
                        && this.BookCount == b.BookCount;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.ID, this.Name, this.BookCount);
            }
        }
        public IEnumerable<NotReturned> DidNotReturned()
        {
            var g = from p in this.personrepo.ReadAll()
                    join r in this.rentrepo.ReadAll()
                    on p.PersonID equals r.PersonID
                    where r.Back == false
                    select new
                    {
                        p.PersonID,
                        p.Name,
                        p.Phone,
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
                       Name = p.Name,
                       PhoneNumber = p.Phone
                   };
        }

        public class NotReturned
        {
            public int BID { get; set; }
            public string Title { get; set; }
            public int PID { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public override bool Equals(object obj)
            {
                NotReturned b = obj as NotReturned;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.BID == b.BID
                        && this.Title == b.Title
                        && this.PID == b.PID
                        && this.Name == b.Name
                        && this.PhoneNumber == b.PhoneNumber;

                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.BID, this.Title, this.PID, this.Name, this.PhoneNumber);

            }
        }

        public IEnumerable<RentedIt> RentedBy(int bookid)
        {
            return from r in rentrepo.ReadAll()
                   join p in personrepo.ReadAll()
                   on r.PersonID equals p.PersonID
                   where r.BookID == bookid
                   select new RentedIt()
                   {
                       ID = p.PersonID,
                       Name = p.Name,
                       PhoneNumber = p.Phone

                   };


        }

        public class RentedIt
        {

            public int ID { get; set; }
            public string Name { get; set; }
            public string PhoneNumber { get; set; }
            public override bool Equals(object obj)
            {
                RentedIt b = obj as RentedIt;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.ID == b.ID
                        && this.Name == b.Name
                        && this.PhoneNumber == b.PhoneNumber;


                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.ID, this.Name, this.PhoneNumber);

            }


        }




    }

}
