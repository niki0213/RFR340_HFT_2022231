using System;
using Microsoft.EntityFrameworkCore;
using RFR340_HFT_2022231.Models;

namespace RFR340_HFT_2022231.Repository
{
    public class LibraryDbContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
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
            modelBuilder.Entity<Books>()
                .HasOne(b => b.Publisher)
                .WithMany(p => p.Books)
                .HasForeignKey(b => b.PublisherID)
                .OnDelete(DeleteBehavior.Cascade);
            

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Books)
                .WithMany(b => b.Person)
                .UsingEntity<Rent>(
                    r => r.HasOne(r => r.Books).WithMany()
                       .HasForeignKey(r => r.BookID).OnDelete(DeleteBehavior.Cascade),
                    r => r.HasOne(r => r.Person).WithMany()
                       .HasForeignKey(r => r.PersonID).OnDelete(DeleteBehavior.Cascade)
                    );

            modelBuilder.Entity<Rent>()
               .HasOne(r => r.Books)
               .WithMany(b => b.Rent)
               .HasForeignKey(r => r.BookID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Rent>()
                .HasOne(r => r.Person)
                .WithMany(movie => movie.Rent)
                .HasForeignKey(r => r.PersonID)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Books>().HasData(new Books[]
                    {
                         new Books("1001#Harry Potter and the Philosopher's Stone#J. K. Rowling#1997#1"),
                         new Books("1002#Harry Potter and the Chamber of Secrets#J. K. Rowling#1998#1"),
                         new Books("1003#Harry Potter and the Prisoner of Azkaban#J. K. Rowling#1999#1"),
                         new Books("1004#Harry Potter and the Goblet of Fire #J. K. Rowling#2000#1"),
                         new Books("1005#Harry Potter and the Order of the Phoenix #J. K. Rowling#2000#1"),
                         new Books("1006#Harry Potter and the Goblet of Fire #J. K. Rowling#2000#1"),
                         new Books("1007#Harry Potter and the Half-Blood Prince#J. K. Rowling#2003#1"),
                         new Books("1008#Harry Potter and the Deathly Hallows #J. K. Rowling#2005#1"),
                         new Books("1009#Twilight #Stephenie Meyer#2005#2"),
                         new Books("1010#New Moon#Stephenie Meyer#2006#2"),
                         new Books("1011#Eclipse#Stephenie Meyer#2007#2"),
                         new Books("1012#Breaking Dawn#Stephenie Meyer#2006#2"),
                    }
                );
            modelBuilder.Entity<Person>().HasData(new Person[]
                    {
                        new Person("101#Robbie#Miller#3645718270"),
                        new Person("102#Camilla#Donata#3647584920"),
                        new Person("104#Kevin#Mahaut#3682936152"),
                        new Person("105#Dalma#Wibke#3637458265"),
                        new Person("106#Henri#Suse#3682951536")
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
                        new Rent("11#1008#102#2022.02.13#2022.05.16"),
                        new Rent("12#1001#101#2022.04.20#2022.05.20"),
                        new Rent("13#1003#104#2022.03.13#2022.04.02"),
                        new Rent("14#1007#105#2022.02.01#2022.04.16"),
                        new Rent("15#1008#104#2022.02.13#2022.05.16"),
                        new Rent("16#1001#102#2022.02.13#2022.05.16"),
                        new Rent("17#1004#100#2022.02.13#2022.05.16"),
                        new Rent("18#1009#104#2022.02.13#2022.05.16"),
                        new Rent("19#1007#102#2022.02.13#3000.01.01"),
                        new Rent("20#1003#106#2022.02.13#3000.01.01")

                    }
                );


        }

    }
}
