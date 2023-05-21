using System;
using Microsoft.EntityFrameworkCore;
using RFR340_HFT_2022231.Models;

namespace RFR340_HFT_2022231.Repository
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public LibraryDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseInMemoryDatabase("Library")
                .UseLazyLoadingProxies();
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(b => b
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherID)
                .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Person>()
                .HasMany(p => p.Books)
                .WithMany(b => b.Person)
                .UsingEntity<Rent>(
                    r => r.HasOne(r => r.Book).WithMany()
                       .HasForeignKey(r => r.BookID).OnDelete(DeleteBehavior.Cascade),
                    r => r.HasOne(r => r.Person).WithMany()
                       .HasForeignKey(r => r.PersonID).OnDelete(DeleteBehavior.Cascade)
                    );

            modelBuilder.Entity<Rent>()
               .HasOne(r => r.Book)
               .WithMany(b => b.Rent)
               .HasForeignKey(r => r.BookID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rent>()
                .HasOne(r => r.Person)
                .WithMany(p => p.Rent)
                .HasForeignKey(r => r.PersonID)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Book>().HasData(new Book[]
                    {
                         new Book("1#Harry Potter and the Philosopher's Stone#J. K. Rowling#1"),
                         new Book("2#Harry Potter and the Chamber of Secrets#J. K. Rowling#1"),
                         new Book("3#Harry Potter and the Prisoner of Azkaban#J. K. Rowling#1"),
                         new Book("4#Harry Potter and the Goblet of Fire #J. K. Rowling#1"),
                         new Book("5#Harry Potter and the Order of the Phoenix #J. K. Rowling#1"),
                         new Book("6#Harry Potter and the Goblet of Fire #J. K. Rowling#1"),
                         new Book("7#Harry Potter and the Half-Blood Prince#J. K. Rowling#1"),
                         new Book("8#Harry Potter and the Deathly Hallows #J. K. Rowling#1"),
                         new Book("9#Twilight #Stephenie Meyer#2"),
                         new Book("10#New Moon#Stephenie Meyer#2"),
                         new Book("11#Eclipse#Stephenie Meyer#2"),
                         new Book("12#Breaking Dawn#Stephenie Meyer#2"),
                    }
                );
            modelBuilder.Entity<Person>().HasData(new Person[]
                    {
                        new Person("1#Robbie Miller#3645718270"),
                        new Person("2#Camilla Donata#3647584920"),
                        new Person("3#Kevin Mahaut#3682936152"),
                        new Person("4#Dalma Wibke#3637458265"),
                        new Person("5#Henri Suse#3682951536")
                    }
                );
            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
                    {
                        new Publisher("1#Bloomsbury"),
                        new Publisher("2#Little, Brown and Company")
                    }
                );
            modelBuilder.Entity<Rent>().HasData(new Rent[]
                    {
                        new Rent("1#8#2#1"),
                        new Rent("2#1#1#1"),
                        new Rent("3#3#4#0"),
                        new Rent("4#7#5#1"),
                        new Rent("5#8#4#0"),
                        new Rent("6#1#2#1"),
                        new Rent("7#4#3#1"),
                        new Rent("8#9#4#0"),
                        new Rent("9#7#2#1"),
                        new Rent("10#3#6#0")

                    }
                );


        }

    }
}
