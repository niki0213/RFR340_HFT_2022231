using RFR340_HFT_2022231.Models;
using System.Linq;

namespace RFR340_HFT_2022231.Logic
{
    public interface IBookLogic
    {
        void Create(Book item);
        void Delete(int id);
        Book Read(int id);
        IQueryable<Book> ReadAll();
        void Update(Book item);
    }
}