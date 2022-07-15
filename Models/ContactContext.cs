using System;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options)
            : base(options)
        { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friend" },
                new Category { CategoryId = 3, Name = "Work" },
                new Category { CategoryId = 4, Name = "Other" }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    Firstname = "Mary Ellen",
                    Lastname = "Walton",
                    Phone = "555-123-4567",
                    Email = "MaryEllen@yahoo.com",
                    CategoryId = 1,
                    DateAdded = DateTime.Now
                },
                new Contact
                {
                    ContactId = 2,
                    Firstname = "Delores",
                    Lastname = "Del Rio",
                    Phone = "555-987-6543",
                    Email = "delores@hotmail.com",
                    CategoryId = 2,
                    DateAdded = DateTime.Now
                },
                new Contact
                {
                    ContactId = 3,
                    Firstname = "Efren",
                    Lastname = "Herrera",
                    Phone = "555-456-7890",
                    Email = "efren@aol.com",
                    CategoryId = 3,
                    DateAdded = DateTime.Now
                }
            );
        }
    }
}
