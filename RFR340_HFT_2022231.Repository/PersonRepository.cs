using RFR340_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Repository
{
    public class PersonRepository : Repository<Person>, IRepository<Person>
    {
        public PersonRepository(LibraryDbContext Library) : base(Library)
        {
        }

        public override Person Read(int id)
        {
            return Library.Person.FirstOrDefault(t => t.PersonID == id);
        }

        public override void Update(Person person)
        {
            var old = Read(person.PersonID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(person));
                }
            }
            Library.SaveChanges();
        }
    }
}
