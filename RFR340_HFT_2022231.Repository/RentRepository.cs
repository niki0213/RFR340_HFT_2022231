using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Repository
{
    public class RentRepository : Repository<Rent>, IRepository<Rent>
    {
        public RentRepository(LibraryDbContext Library) : base(Library)
        {
        }

        public override Rent Read(int id)
        {
            return Library.Rent.FirstOrDefault(t => t.RentID == id);
        }

        public override void Update(Rent rent)
        {
            var old = Read(rent.RentID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(rent));
                }
            }
            Library.SaveChanges();
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
            return from x in rentrepo.ReadAll()
                   where x.PersonID == ID
                   select new BookInfo()
                   {
                       ID = x.BookID,
                       Title = x.Book.Title
                   };

        }
        public IEnumerable<PublisherInfo> PublishedBooks()
        {
            return from b in this.repo.ReadAll()
                   group b by b.PublisherID into g

                   select new PublisherInfo()
                   {
                       ID = g.Key,
                   };
        }
        public IEnumerable<NotReturned> DidNotReturned()
        {
            return from r in this.rentrepo.ReadAll()
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
            return from r in rentrepo.ReadAll()
                   where r.BookID == bookid
                   select new RentedIt()
                   {
                       ID = r.Person.PersonID,
                       Name = r.Person.Name,
                       PhoneNumber = r.Person.Phone

                   };
        }
    }
}
