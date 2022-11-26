using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Logic
{
    public class BookLogic
    {
        IRepository<Books> repo;

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
    }
}
