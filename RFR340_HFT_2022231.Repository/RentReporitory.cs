using RFR340_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Repository
{
    public class RentReporitory : Repository<Rent>, IRepository<Rent>
    {
        public RentReporitory(LibraryDbContext Library) : base(Library)
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
    }
}
