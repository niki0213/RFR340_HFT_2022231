using RFR340_HFT_2022231.Logic;
using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;


namespace RFR340_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var Library = new LibraryDbContext();
            var repo =new BooksRepository(Library);
            var logic = new BookLogic(repo);
            



        }
    }
}
