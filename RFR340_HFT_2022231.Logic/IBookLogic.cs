using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RFR340_HFT_2022231.Models;

namespace RFR340_HFT_2022231.Logic
{
    public interface IBookLogic
    {
        void Create(Books item);
        void Delete(int id);
        Books Read(int id);
        IQueryable<Books> ReadAll();
        void Update(Books item);
    }
}
