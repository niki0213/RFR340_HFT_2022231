﻿using RFR340_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Repository
{
    public class BooksRepository: Repository<Books>, IRepository<Books>
    {
        public BooksRepository(LibraryDbContext Library) : base(Library)
        {
        }

        public override Books Read(int id)
        {
            return Library.Books.FirstOrDefault(t => t.BookID == id);
        }

        public override void Update(Books book)
        {
            var old = Read(book.BookID);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(book));
                }
            }
            Library.SaveChanges();
        }
    }
}
