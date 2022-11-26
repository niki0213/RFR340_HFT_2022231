using System;
using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Repository;
using RFR340_HFT_2022231.Logic;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace RFR340_HFT_2022231.Test
{
    [TestFixture]
    public class LibraryLogicTester
    {
        RentLogic rentLogic;
        Mock<IRepository<Rent>> mockRent;
        [SetUp]
        public void Rent()
        {
            mockRent = new Mock<IRepository<Rent>>();
            mockRent.Setup(r => r.ReadAll()).Returns(new List<Rent>()
            {
                new Rent("1001#1#111#2000.01.01#2000.02.02"),
                new Rent("1002#2#112#2000.01.01#2000.02.02"),
                new Rent("1003#1#113#2000.01.01#2000.02.02"),

            }.AsQueryable());
            rentLogic = new RentLogic(mockRent.Object);
        }

        BookLogic bookLogic;
        Mock<IRepository<Books>> mockBooks;
        [SetUp]
        public void Book()
        {
            mockBooks = new Mock<IRepository<Books>>();
            mockBooks.Setup(r => r.ReadAll()).Returns(new List<Books>()
            {
                new Books("1#BookA#Author1#2#11"),
                new Books("2#BookB#Author2#1#12"),
                new Books("3#BookC#Author3#5#11"),
                new Books("4#BookD#Author4#7#13")
               
            }.AsQueryable());
            bookLogic = new BookLogic(mockBooks.Object);
        }

        PersonLogic personLogic;
        Mock<IRepository<Person>> mockPerson;
        [SetUp]
        public void Person()
        {
            mockPerson = new Mock<IRepository<Person>>();
            mockPerson.Setup(r => r.ReadAll()).Returns(new List<Person>()
            {
               new Person("111#A#A#1"),
               new Person("112#B#B#1"),
               new Person("113#C#C#1"),
               new Person("114#D#D#1")

            }.AsQueryable());
            personLogic = new PersonLogic(mockPerson.Object);
        }

        PublisherLogic publisherLogic;
        Mock<IRepository<Publisher>> mockPublisher;
        [SetUp]
        public void Publisher()
        {
            mockPublisher = new Mock<IRepository<Publisher>>();
            mockPublisher.Setup(r => r.ReadAll()).Returns(new List<Publisher>()
            {
               new Publisher("11#A"),
               new Publisher("12#B"),
               new Publisher("13#C"),
            }.AsQueryable());
            personLogic = new PersonLogic(mockPerson.Object);
        }

    }
}
