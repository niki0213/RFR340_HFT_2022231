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
                         new Books("71606#Harry Potter and the Philosopher's Stone#J. K. Rowling#1997#38605"),
                         new Books("71607#Harry Potter and the Philosopher's Stone#J. K. Rowling#1997#38605"),
                         new Books("71608#Harry Potter and the Philosopher's Stone#J. K. Rowling#1997#38605"),
                         new Books("71609#Harry Potter and the Philosopher's Stone#J. K. Rowling#1997#38605"),
                    }
                );
            modelBuilder.Entity<Person>().HasData(new Person[]
                    {
                        new Person("19085#Robbie#Miller#93513655070")
                    }
                );
            modelBuilder.Entity<Publisher>().HasData(new Publisher[]
                    {
                        new Publisher("38605#Bloomsbury")
                    }
                );
            modelBuilder.Entity<Rent>().HasData(new Rent[]
                    {
                        new Rent("2001#71606#19085#2022.02.13#2022.05.16")
                    }
                );


        }

    }
}
