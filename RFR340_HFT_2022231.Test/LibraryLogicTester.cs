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

        [SetUp]
        public void Init()
        {
            mockRent = new Mock<IRepository<Rent>>();
            mockBooks = new Mock<IRepository<Book>>();
            mockPerson = new Mock<IRepository<Person>>();
            mockPublisher = new Mock<IRepository<Publisher>>();
            var book1 =
            new Book()
            {
                BookID = 1,
                Title = "A",
                PublisherID = 1001,
            };
            var book2 =
            new Book()
            {
                BookID = 2,
                Title = "B",
                PublisherID = 1001,
            };
            var person1 = new Person()
            {
                PersonID = 11,
                Name = "J",
                Phone = "11"
            };
            var person2 = new Person()
            {
                PersonID = 12,
                Name = "L",
                Phone = "11"
            };
            var books = new List<Book>();
            books.Add(book1);
            books.Add(book2);
            var publisher = new Publisher()
            {
                PublisherID = 1001,
                Name = "W",
                Books=books

            };
            var rent1 = new Rent()
            {
                RentID = 101,
                BookID = 1,
                PersonID = 11,
                Back = false,
                Person=person1,
                Book=book1
            };
            var rent2 = new Rent()
            {
                RentID = 102,
                BookID = 2,
                PersonID = 11,
                Back = true,
                Person = person1,
                Book = book2
            };
            var rent3 = new Rent()
            {
                RentID = 103,
                BookID = 1,
                PersonID = 12,
                Back = false,
                Person = person2,
                Book = book1
            };
            var books1=books.AsQueryable();
            var rents = new List<Rent>()
            {
                rent1, rent2, rent3
            }.AsQueryable();
            var person = new List<Person>
            {
                person1, person2
            }.AsQueryable();
            var publishers = new List<Publisher>
            {
               publisher
            }.AsQueryable();
            mockBooks.Setup(t => t.ReadAll()).Returns(books1);
            mockPerson.Setup(t => t.ReadAll()).Returns(person);
            mockPublisher.Setup(t => t.ReadAll()).Returns(publishers);
            mockRent.Setup(t => t.ReadAll()).Returns(rents);
            bookLogic = new BookLogic(mockBooks.Object);
            rentLogic = new RentLogic(mockRent.Object);
            personLogic = new PersonLogic(mockPerson.Object);
            publisherLogic = new PublisherLogic(mockPublisher.Object);
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
                Name = "ABCDEF",

            };

            publisherLogic.Create(publisher);
            mockPublisher.Verify(r => r.Create(publisher), Times.Once);

        }

        [Test]
        public void BookReadCounter()
        {
            var actual = rentLogic.BookReadCounter().ToList();
            var expected = new List<BookReadCount>()
            {
                new BookReadCount()
                {
                    Id=1,
                    Count=2
                },
                 new BookReadCount()
                {
                    Id=2,
                    Count=1
                },

            };
            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void HaveRead()
        {
            var actual = rentLogic.HaveRead(11).ToList();
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
            var actual = bookLogic.PublishedBooks().ToList();
            var expected = new List<PublisherInfo>()
            {
                new PublisherInfo()
                {
                       ID = 1001,
                       BookCount = 2

                },


            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DidNotReturned()
        {
            var actual = rentLogic.DidNotReturned().ToList();
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
            var actual = rentLogic.RentedBy(1).ToList();
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
