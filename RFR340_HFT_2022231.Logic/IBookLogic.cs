using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace RFR340_HFT_2022231.Logic
{
    public interface IBookLogic
    {
        void Create(Book item);
        void Delete(int id);
        IEnumerable<PublisherInfo> PublishedBooks();
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book item);
    }
}