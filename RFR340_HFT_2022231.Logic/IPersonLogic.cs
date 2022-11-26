using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RFR340_HFT_2022231.Models;

namespace RFR340_HFT_2022231.Logic
{
    public interface IPersonLogic
    {
        void Create(Person item);
        void Delete(int id);
        Person Read(int id);
        IQueryable<Person> ReadAll();
        void Update(Person item);
    }
}
