using System;
using System.Linq;
using System.Numerics;
using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Repository;

namespace RFR340_HFT_2022231.Logic
{
    public class RentLogic: IRentLogic
    {
        public IRepository<Rent> repo;

        public RentLogic(IRepository<Rent> repo)
        {
            this.repo = repo;
        }

        public void Create(Rent item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Rent Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Rent> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Rent item)
        {
            this.repo.Update(item);
        }

    }
}
