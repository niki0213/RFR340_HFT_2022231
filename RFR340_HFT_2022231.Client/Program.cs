using ConsoleTools;
using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Models.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Numerics;


namespace RFR340_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Enter the Book's ID: ");
                int ID = int.Parse(Console.ReadLine());
                Console.Write("Enter the Book's title: ");
                string title = Console.ReadLine();
                Console.Write("Enter the Books's' author: ");
                string a = Console.ReadLine();
                Console.Write("Enter the Book's publisher id: ");
                int id = int.Parse(Console.ReadLine());
                rest.Post(new Book() { BookID = ID, Title = title, Author = a, PublisherID = id }, "book") ;
            }
            else if (entity == "Rent")
            {
                Console.Write("Enter the Rent's ID: ");
                int ID = int.Parse(Console.ReadLine());
                Console.Write("Enter the BookID: ");
                int book = int.Parse(Console.ReadLine());
                Console.Write("Enter the PersonID: ");
                int person = int.Parse(Console.ReadLine());
                rest.Post(new Rent() { RentID=ID, BookID = book, PersonID = person, Back=false }, "rent");
            }

            else if (entity == "Publisher")
            {
                Console.Write("Enter the publisher's name: ");
                string name = Console.ReadLine();
                rest.Post(new Publisher() { Name = name }, "publisher");
            }
            else if (entity == "Person")
            {
                Console.Write("Enter the Persons's ID: ");
                int ID = int.Parse(Console.ReadLine());
                Console.Write("Enter the Persons's name: ");
                string name = Console.ReadLine();
                Console.Write("Enter the Persons's phone number: ");
                string phone = Console.ReadLine();
                rest.Post(new Person() { PersonID=ID, Name = name, Phone = phone}, "person");
            }

        }
        static void List(string entity)
        {
            if (entity == "Book")
            {
                List<Book> books = rest.Get<Book>("book");
                foreach (var item in books)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else if (entity == "Rent")
            {
                List<Rent> rent = rest.Get<Rent>("rent");
                foreach (var item in rent)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else if (entity == "Person")
            {
                List<Person> rent = rest.Get<Person>("person");
                foreach (var item in rent)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else if (entity == "Publisher")
            {
                List<Publisher> rent = rest.Get<Publisher>("publisher");
                foreach (var item in rent)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Enter Book's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Book one = rest.Get<Book>(id, "book");
                Console.Write($"New title [old: {one.Title}]: ");
                string name = Console.ReadLine();
                one.Title = name;
                rest.Put(one, "book");
            }
            else if (entity == "Rent")
            {
                Console.Write("Enter rent's id to update that the book is back: ");
                int id = int.Parse(Console.ReadLine());
                Rent one = rest.Get<Rent>(id, "rent");
                Console.Write($"bookID: {one.BookID}");
                one.Back = true;
                rest.Put(one, "rent");
            }
            else if (entity == "Person")
            {
                Console.Write("Enter Person's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Person one = rest.Get<Person>(id, "person");
                Console.Write($"New phone number [old: {one.Phone}]: ");
                string phone = Console.ReadLine();
                one.Phone = phone;
                rest.Put(one, "person");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter Publishers's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Publisher one = rest.Get<Publisher>(id, "publisher");
                Console.Write($"New name [old: {one.Name}]: ");
                one.Name = Console.ReadLine();
                rest.Put(one, "publisher");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Enter Book's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "book");
            }
            else if (entity == "Rent")
            {
                Console.Write("Enter Rent's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "rent");
            }
            else if (entity == "Person")
            {
                Console.Write("Enter Person's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "person");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter Publisher's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "publisher");
            }
        }
        static void Read(string entity)
        {
            if (entity == "Book")
            {
                Console.Write("Enter Book's id to read: ");
                int id = int.Parse(Console.ReadLine());
                var item = rest.Get<Book>(id, "book");
                Console.WriteLine(item.ToString());

            }
            else if (entity == "Rent")
            {
                Console.Write("Enter Rent's id to read: ");
                int id = int.Parse(Console.ReadLine());
                var item = rest.Get<Rent>(id, "rent");
                Console.WriteLine(item.ToString());
            }
            else if (entity == "Person")
            {
                Console.Write("Enter Person's id to read: ");
                int id = int.Parse(Console.ReadLine());
                var item = rest.Get<Person>(id, "person");
                Console.WriteLine(item.ToString());
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter Publisher's id to read: ");
                int id = int.Parse(Console.ReadLine());
                var item = rest.Get<Publisher>(id, "publisher");
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

        }
        static void BookReadCounter()
        {
            var BRC = rest.Get<BookReadCount>("method/BookReadCounter");
            foreach (var item in BRC)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

        }
        static void HaveRead()
        {
            Console.Write("Enter Person's ID: ");
            int id = int.Parse(Console.ReadLine());
            var HV = rest.Get<BookInfo>($"Method/HaveRead?id={id}");
            foreach (var item in HV)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();

        }
        static void PublishedBooks()
        {
            var PB = rest.Get<PublisherInfo>("Method2/PublishedBooks");
            foreach (var item in PB)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void DidNotReturned()
        {
            var DR = rest.Get<NotReturned>("Method/DidNotReturned");
            foreach (var item in DR)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }
        static void RentedBy()
        {
            Console.Write("Enter Book's ID: ");
            int id = int.Parse(Console.ReadLine());
            var RB = rest.Get<RentedIt>($"Method/RentedBy?id={id}");
            foreach (var item in RB)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        static void Main(string[] args)
        {

            rest = new RestService("http://localhost:4738/", "book");


            Console.WriteLine("Hello");
            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Book"))
                .Add("Create", () => Create("Book"))
                .Add("Delete", () => Delete("Book"))
                .Add("Update", () => Update("Book"))
                .Add("Read", () => Read("Book"))
                .Add("Exit", ConsoleMenu.Close);

            var personSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Person"))
                .Add("Create", () => Create("Person"))
                .Add("Delete", () => Delete("Person"))
                .Add("Update", () => Update("Person"))
                .Add("Read", () => Read("Person"))
                .Add("Exit", ConsoleMenu.Close);

            var rentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Rent"))
                .Add("Create", () => Create("Rent"))
                .Add("Delete", () => Delete("Rent"))
                .Add("Update", () => Update("Rent"))
                .Add("Read", () => Read("Rent"))
                .Add("Exit", ConsoleMenu.Close);

            var publisherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Publisher"))
                .Add("Create", () => Create("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Read", () => Read("Publisher"))
                .Add("Exit", ConsoleMenu.Close);

            var methodSubMenu = new ConsoleMenu(args, level: 1)
                .Add("BookReadCounter", () => BookReadCounter())
                .Add("HaveRead", () => HaveRead())
                .Add("PublishedBooks", () => PublishedBooks())
                .Add("DidNotReturned", () => DidNotReturned())
                .Add("RentedBy", () => RentedBy())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Book", () => bookSubMenu.Show())
                .Add("Person", () => personSubMenu.Show())
                .Add("Rent", () => rentSubMenu.Show())
                .Add("Publisher", () => publisherSubMenu.Show())
                .Add("Method", () => methodSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();



        }
    }
}
