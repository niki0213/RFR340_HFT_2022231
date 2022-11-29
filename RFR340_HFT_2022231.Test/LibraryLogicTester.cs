using System;
using RFR340_HFT_2022231.Models;
using RFR340_HFT_2022231.Models.DTO;
using RFR340_HFT_2022231.Repository;
using RFR340_HFT_2022231.Logic;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Linq;

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
        Mock<IRepository<Book>> mockBooks;
        PersonLogic personLogic;
        Mock<IRepository<Person>> mockPerson;
        PublisherLogic publisherLogic;
        Mock<IRepository<Publisher>> mockPublisher;
        BookLogic logic;

        [SetUp]
        public void Init()
        {
            mockRent = new Mock<IRepository<Rent>>();
            mockBooks = new Mock<IRepository<Book>>();
            mockPerson = new Mock<IRepository<Person>>();
            mockPublisher = new Mock<IRepository<Publisher>>();
            var rent1 = new Rent()
            {
                RentID = 101,
                BookID = 1,
                PersonID = 11,
                Start = new DateTime(2022, 11, 1),
                Back = false
            };
            var rent2 = new Rent()
            {
                RentID = 101,
                BookID = 1,
                PersonID = 11,
                Start = new DateTime(2022, 11, 1),
                Back = false
            };
            var rent3 = new Rent()
            {
                RentID = 101,
                BookID = 1,
                PersonID = 11,
                Start = new DateTime(2022, 11, 1),
                Back = false
            };
            mockRent.Setup(r => r.ReadAll()).Returns(new List<Rent>()
            {
                new Rent()
                {
                    RentID=101,
                    BookID=1,
                    PersonID=11,
                    Start=new DateTime(2022,11,1),
                    Back=false
                },
                 new Rent()
                {
                    RentID=102,
                    BookID=2,
                    PersonID=11,
                    Start=new DateTime(2022,11,1),
                    Back=true,

                },
                new Rent()
                {
                    RentID=103,
                    BookID=1,
                    PersonID=12,
                    Start=new DateTime(2022,11,1),
                    Back= false

                },

            }.AsQueryable()); ;
            rentLogic = new RentLogic(mockRent.Object);
            mockBooks = new Mock<IRepository<Book>>();
            mockBooks.Setup(r => r.ReadAll()).Returns(new List<Book>()
            {
               new Book()
               {
                   BookID=1,
                   Title="A",
                   PublisherID=1001,
               },
                new Book()
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
                   Name="J",
                   Phone="11"
               },
                new Person()
               {
                   PersonID=12,
                   Name="L",
                   Phone="11"
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
        public void CreatePersonshortphonenumber()
        {
            var person = new Person()
            {
                PersonID = 11,
                Name = "Joe Smith",
                Phone = "11"
            };
            try
            {
                personLogic.Create(person);
            }
            catch
            {


            }
            mockPerson.Verify(r => r.Create(person), Times.Never);
        }
        [Test]
        public void CreatePersonshortname()
        {
            var person = new Person()
            {
                PersonID = 11,
                Name = "J",
                Phone = "1234567890"
            };
            try
            {
                personLogic.Create(person);
            }
            catch
            {


            }
            mockPerson.Verify(r => r.Create(person), Times.Never);
        }
        [Test]
        public void CreatePerson()
        {
            var person = new Person()
            {
                PersonID = 11,
                Name = "Joe Smith",
                Phone = "1234567890"
            };
            try
            {
                personLogic.Create(person);
            }
            catch
            {


            }
            mockPerson.Verify(r => r.Create(person), Times.Once);
        }
        [Test]
        public void CreateBook()
        {
            var book = new Book()
            {
                BookID = 1,
                Title = "A",
                PublisherID = 1001,
            };
            try
            {
                bookLogic.Create(book);
            }
            catch
            {


            }
            mockBooks.Verify(r => r.Create(book), Times.Never);

        }
        [Test]
        public void CreatPublisherTooShort()
        {
            var publisher = new Publisher()
            {
                PublisherID = 1,
                Name = "A",

            };
            try
            {
                publisherLogic.Create(publisher);
            }
            catch
            {


            }
            mockPublisher.Verify(r => r.Create(publisher), Times.Never);

        }
        [Test]
        public void CreatPublisher()
        {
            var publisher = new Publisher()
            {
                PublisherID = 1,
                Name = "ABCDE",

            };

            publisherLogic.Create(publisher);
            mockPublisher.Verify(r => r.Create(publisher), Times.Once);

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
                    //Title="A"

                },
                new BookInfo()
                {
                    ID=2,
                    //Title="B"

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
                       PID = 11,
                       Name = "J",
                       PhoneNumber = "11"

                },
                 new NotReturned()
                {
                       BID = 1,
                       Title = "A",
                       PID = 12,
                       Name = "L",
                       PhoneNumber = "11"

                }


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
                   Name="J",
                   PhoneNumber="11"
               },
                new RentedIt()
               {
                   ID=12,
                   Name="L",
                   PhoneNumber="11"
               }




            };
            Assert.AreEqual(expected, actual);
        }


    }
}
