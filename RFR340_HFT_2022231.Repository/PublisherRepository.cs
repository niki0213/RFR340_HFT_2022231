using RFR340_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Repository
{

    public class PublisherRepository : Repository<Publisher>, IRepository<Publisher>
    {

        public PublisherRepository(LibraryDbContext Library) : base(Library)
        {
        }

        public override Publisher Read(int id)
        {
            return Library.Publisher.FirstOrDefault(t => t.PublisherID == id);
        }

        public override void Update(Publisher publisher)
        {
            var old = Read(publisher.PublisherID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(publisher));
                }
            }
            Library.SaveChanges();
        }
    }
}
