using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Repository;
using System.Collections.Generic;
using System.Linq;

namespace RFR340_HFT_2022231.Logic
{
    public interface IBookLogic
    {
        IEnumerable<BookLogic.BookReadCount> BookReadCounter();
        void Create(Books item);
        void Delete(int id);
        IEnumerable<BookLogic.NotReturned> DidNotReturned();
        IEnumerable<BookLogic.BookInfo> HaveRead(int ID);
        IEnumerable<BookLogic.PublisherInfo> PublishedBooks();
        Books Read(int id);
        IQueryable<Books> ReadAll();
        IEnumerable<BookLogic.RentedIt> RentedBy(int bookid);
        void Update(Books item);
    }
}