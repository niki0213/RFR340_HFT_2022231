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
                Books newbook = new Books();
                Console.Write("Enter the book's title: ");
                newbook.Title = Console.ReadLine();
                Console.Write("Enter the book's author: ");
                newbook.Author = Console.ReadLine();
                Console.Write("Enter the book's publication year: ");
                newbook.PublicationYear = int.Parse(Console.ReadLine());
                Console.Write("Enter enter book's publisherID: ");
                newbook.PublisherID = int.Parse(Console.ReadLine());
                rest.Post(newbook, "books");
            }
            else if (entity == "Rent")
            {
                var newrent = new Rent();
                Console.Write("Enter the Books ID: ");
                newrent.BookID = int.Parse(Console.ReadLine());
                Console.Write("Enter the PersonID: ");
                newrent.PersonID = int.Parse(Console.ReadLine());
                Console.Write("Enter the rents star date in the format of yyyy.mm.dd: ");
                string[] dates = Console.ReadLine().Split('.');
                newrent.Start = new DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]));
                Console.Write("Enter the rents end date in the format of yyyy.mm.dd: ");
                string[] dates2 = Console.ReadLine().Split('.');
                newrent.End = new DateTime(int.Parse(dates2[0]), int.Parse(dates2[1]), int.Parse(dates2[2]));
                rest.Post(newrent, "rent");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter the publisher's name: ");
                string name =Console.ReadLine();
                rest.Post(new Publisher() { Name = name },"publisher");
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
                Console.Write($"New end date: ");
                string[] dates = Console.ReadLine().Split('.');
                one.End = new DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]));
                rest.Put(one, "rent");
            }
            else if (entity == "Person")
            {
                Console.Write("Enter rent's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Rent one = rest.Get<Rent>(id, "rent");
                Console.Write($"New end date: ");
                string[] dates = Console.ReadLine().Split('.');
                one.End = new DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]));
                rest.Put(one, "rent");
            }
            else if (entity == "Publisher")
            {
                Console.Write("Enter rent's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Rent one = rest.Get<Rent>(id, "rent");
                Console.Write($"New end date: ");
                string[] dates = Console.ReadLine().Split('.');
                one.End = new DateTime(int.Parse(dates[0]), int.Parse(dates[1]), int.Parse(dates[2]));
                rest.Put(one, "rent");
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
            var logicSubMenu = new ConsoleMenu(args, level: 1)
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
                .Add("Logic", () => logicSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();



        }
    }
}
