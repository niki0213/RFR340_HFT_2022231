using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace RFR340_HFT_2022231.Logic
{
    public interface IRentLogic
    {
        IEnumerable<BookReadCount> BookReadCounter();
        void Create(Rent item);
        void Delete(int id);
        IEnumerable<NotReturned> DidNotReturned();
        IEnumerable<BookInfo> HaveRead(int ID);
        Rent Read(int id);
        IQueryable<Rent> ReadAll();
        IEnumerable<RentedIt> RentedBy(int bookid);
        void Update(Rent item);
    }
}