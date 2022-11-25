using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected LibraryDbContext Library;
        public Repository(LibraryDbContext Library)
        {
            this.Library = Library;
        }
        public void Create(T item)
        {
            Library.Set<T>().Add(item);
            Library.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return Library.Set<T>();
        }

        public void Delete(int id)
        {
            Library.Set<T>().Remove(Read(id));
            Library.SaveChanges();
        }

        public abstract T Read(int id);
        public abstract void Update(T item);
    }
}
