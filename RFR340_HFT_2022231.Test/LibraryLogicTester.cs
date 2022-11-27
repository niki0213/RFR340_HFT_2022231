using System;
using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Repository;
using RFR340_HFT_2022231.Logic;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;
using static RFR340_HFT_2022231.Logic.RentLogic;
using static RFR340_HFT_2022231.Logic.BookLogic;
using System.Threading;

namespace RFR340_HFT_2022231.Test
{
    [TestFixture]
    public class LibraryLogicTester
    {
        RentLogic rentLogic;
        Mock<IRepository<Rent>> mockRent;
        BookLogic bookLogic;
        Mock<IRepository<Books>> mockBooks;
        PersonLogic personLogic;
        Mock<IRepository<Person>> mockPerson;
        PublisherLogic publisherLogic;
        Mock<IRepository<Publisher>> mockPublisher;
        BookLogic logic;

        [SetUp]
        public void Init()
        {
            mockRent = new Mock<IRepository<Rent>>();
            mockRent.Setup(r => r.ReadAll()).Returns(new List<Rent>()
            {
                new Rent()
                {
                    RentID=101,
                    BookID=1,
                    PersonID=11,
                    End=new DateTime(2002,02,13)
                },
                 new Rent()
                {
                    RentID=102,
                    BookID=2,
                    PersonID=11,
                    End=new DateTime(2022,12,1)

                }, 
                new Rent()
                {
                    RentID=103,
                    BookID=1,
                    PersonID=12,
                    End=new DateTime(3000,1,1)

                },

            }.AsQueryable());;
            rentLogic = new RentLogic(mockRent.Object);
            mockBooks = new Mock<IRepository<Books>>();
            mockBooks.Setup(r => r.ReadAll()).Returns(new List<Books>()
            {
               new Books()
               {
                   BookID=1,
                   Title="A",
                   PublisherID=1001,
               },
                new Books()
               {
                   BookID=2,
                   Title="B",
                   PublisherID=1001,
               }

            }.AsQueryable());
            bookLogic = new BookLogic(mockBooks.Object);


            mockPerson = new Mock<IRepository<Person>>();
            mockPerson.Setup(r => r.ReadAll()).Returns(new List<Person>()
            {
               new Person()
               {
                   PersonID=11,
                   FirstName="J",
                   LastName="K",
                   phone="11"
               },
                new Person()
               {
                   PersonID=12,
                   FirstName="L",
                   LastName="M",
                   phone="11"
               }

            }.AsQueryable());
            personLogic = new PersonLogic(mockPerson.Object);
            mockPublisher = new Mock<IRepository<Publisher>>();
            mockPublisher.Setup(r => r.ReadAll()).Returns(new List<Publisher>()
            {
               new Publisher()
               {
                   PublisherID=1001,
                   Name="W"

               }
            }.AsQueryable());
            publisherLogic = new PublisherLogic(mockPublisher.Object);
            logic = new BookLogic(mockBooks.Object, mockRent.Object, mockPublisher.Object, mockPerson.Object);
        }


       


        [Test]
        public void CreateRent()
        {
            var Rent = new Rent("1003#1#113#2000.01.01#2000.02.02");
            rentLogic.Create(Rent);

            mockRent.Verify(r => r.Create(Rent), Times.Once);
        }
        [Test]
        public void BookReadCounter()
        {
            var actual = logic.BookReadCounter().ToList();
            var expected = new List<BookReadCount>()
            {
                new BookReadCount()
                {
                    Id=1,
                    Title="A",
                    Count=2
                },
                 new BookReadCount()
                {
                    Id=2,
                    Title="B",
                    Count=1
                },
               
            };
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void HaveRead()
        {
            var actual = logic.HaveRead(11).ToList();
            var expected = new List<BookInfo>()
            {
                new BookInfo()
                {
                    ID=1,
                    Title="A"
                   
                },
                new BookInfo()
                {
                    ID=2,
                    Title="B"

                },

            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PublishedBooks()
        {
            var actual = logic.PublishedBooks().ToList();
            var expected = new List<PublisherInfo>()
            {
                new PublisherInfo()
                {
                       ID = 1001,
                       Name = "W",
                       BookCount = 2

                },
               

            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DidNotReturned()
        {
            var actual = logic.DidNotReturned().ToList();
            var expected = new List<NotReturned>()
            {
                new NotReturned()
                {
                       BID = 1,
                       Title = "A",
                       PID = 12,
                       FirstName = "L",
                       LastName = "M",
                       PhoneNumber = "11"

                },


            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void RentedBy()
        {
            var actual = logic.RentedBy(1).ToList();
            var expected = new List<RentedIt>()
            {
                new RentedIt()
                {
                      
       
                   ID=11,
                   FirstName="J",
                   LastName="K",
                   PhoneNumber="11"
               },
                new RentedIt()
               {
                   ID=12,
                   FirstName="L",
                   LastName="M",
                   PhoneNumber="11"
               }

               


            };
            Assert.AreEqual(expected, actual);
        }


    }
}
