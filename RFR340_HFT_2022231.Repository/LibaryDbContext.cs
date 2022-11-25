using System;
using System.Data;
using Microsoft.EntityFrameworkCore;
using RFR340_HFT_2022231.Models;

namespace RFR340_HFT_2022231.Repository
{
    public class LibaryDbContext : DbContext
    {
        public DbSet<Books> Books { get; set; }
        public DbSet<Rent> Rent { get; set; }
        public DbSet<Person> Person { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (builder.IsConfigured)
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






        }

    }
}
