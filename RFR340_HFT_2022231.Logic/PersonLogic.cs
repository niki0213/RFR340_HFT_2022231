﻿using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFR340_HFT_2022231.Logic
{
    public class PersonLogic: IPersonLogic
    {
        IRepository<Person> repo;

        public PersonLogic(IRepository<Person> repo)
        {
            this.repo = repo;
        }

        public void Create(Person item)
        {
            if (item.Phone.Length != 10)
            {
                throw new ArgumentException("The phone number isn't valid");
            }
            else if (item.Name.Length < 3)
            {
                throw new ArgumentException("The name is too short");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Person Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Person> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Person item)
        {
            this.repo.Update(item);
        }
    }
}
