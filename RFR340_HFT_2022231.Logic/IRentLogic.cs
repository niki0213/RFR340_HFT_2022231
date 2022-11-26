using RFR340_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Logic
{
    public interface IRentLogic
    {
        void Create(Rent item);
        void Delete(int id);
        Rent Read(int id);
        IQueryable<Rent> ReadAll();
        void Update(Rent item);
    }
}
