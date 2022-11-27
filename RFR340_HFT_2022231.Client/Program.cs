using ConsoleTools;
using RFR340_HFT_2022231.Models;
using System;
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
            if (entity == "Books")
            {
                Console.Write("Enter the Book's title: ");
                string title = Console.ReadLine();
                Console.Write("Enter the Books's' author: ");
                string a = Console.ReadLine();
                Console.Write("Enter the Book's publication year: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Enter the Book's publisher id: ");
                int id = int.Parse(Console.ReadLine());
                rest.Post(new Books() { Title = title, Author = a, PublicationYear = year, PublisherID = id }, "books");
            }
            else if (entity == "Rent")
            {
                Console.Write("Enter the BookID: ");
                int book = int.Parse(Console.ReadLine());
                Console.Write("Enter the PersonID: ");
                int person = int.Parse(Console.ReadLine());
                Console.Write("Enter the Book's publication year: ");
                rest.Post(new Rent() { BookID = book, PersonID = person },"rent");
            }
        
            else if (entity == "Publisher")
            {
                Console.Write("Enter the publisher's name: ");
                string name =Console.ReadLine();
                rest.Post(new Publisher() { Name = name },"publisher");
            }
            else if (entity == "Person")
            {
                Console.Write("Enter the Persons's first name: ");
                string fname = Console.ReadLine();
                Console.Write("Enter the Persons's last name: ");
                string lname = Console.ReadLine();
                Console.Write("Enter the Persons's phone: ");
                string phone = Console.ReadLine();
                rest.Post(new Person() { FirstName = fname, LastName = lname, phone = phone }, "person");
            }

        }
        static void List(string entity)
        {
            if (entity == "Books")
            {
                List<Books> books = rest.Get<Books>("books");
                foreach (var item in books)
                {
                    Console.WriteLine(item.BookID + " : " + item.Title + ":\t" + item.Author);
                }
            }
            else if (entity == "Rent")
            {
                List<Rent> rent = rest.Get<Rent>("rent");
                foreach (var item in rent)
                {
                    Console.WriteLine(item.RentID + " : " + item.BookID + " + " + item.PersonID);
                }
            }
            else if (entity == "Person")
            {
                List<Person> rent = rest.Get<Person>("person");
                foreach (var item in rent)
                {
                    Console.WriteLine(item.PersonID + " : " + item.FirstName + " " + item.LastName);
                }
            }
            else if (entity == "Publisher")
            {
                List<Publisher> rent = rest.Get<Publisher>("publisher");
                foreach (var item in rent)
                {
                    Console.WriteLine(item.PublisherID + " : " + item.Name );
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Books")
            {
                Console.Write("Enter Book's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Books one = rest.Get<Books>(id, "books");
                Console.Write($"New title [old: {one.Title}]: ");
                string name = Console.ReadLine();
                one.Title = name;
                rest.Put(one, "books");
            }
            else if (entity == "Rent")
            {
                Console.Write("Enter rent's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Rent one = rest.Get<Rent>(id, "rent");
                Console.Write($"New bookID: ");
                string[] dates = Console.ReadLine().Split('.');
                one.End = new DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]));
                rest.Put(one, "rent");
            }
            else if (entity == "Person")
            {
                Console.Write("Enter Person's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Person one = rest.Get<Person>(id, "person");
                Console.Write($"New phone number [old: {one.phone}]: ");
                string phone = Console.ReadLine();
                one.phone = phone;
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
            if (entity == "Books")
            {
                Console.Write("Enter Book's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "books");
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
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:4738/", "swagger");

           
            Console.WriteLine("Hello");
            var bookSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Books"))
                .Add("Create", () => Create("Books"))
                .Add("Delete", () => Delete("Books"))
                .Add("Update", () => Update("Books"))
                .Add("Exit", ConsoleMenu.Close);

            var personSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Person"))
                .Add("Create", () => Create("Person"))
                .Add("Delete", () => Delete("Person"))
                .Add("Update", () => Update("Person"))
                .Add("Exit", ConsoleMenu.Close);

            var rentSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Rent"))
                .Add("Create", () => Create("Rent"))
                .Add("Delete", () => Delete("Rent"))
                .Add("Update", () => Update("Rent"))
                .Add("Exit", ConsoleMenu.Close);

            var publisherSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Publisher"))
                .Add("Create", () => Create("Publisher"))
                .Add("Delete", () => Delete("Publisher"))
                .Add("Update", () => Update("Publisher"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Books", () => bookSubMenu.Show())
                .Add("Person", () => personSubMenu.Show())
                .Add("Rent", () => rentSubMenu.Show())
                .Add("Publisher", () => publisherSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();



        }
    }
}
