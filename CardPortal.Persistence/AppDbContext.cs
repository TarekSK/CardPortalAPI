using Microsoft.EntityFrameworkCore;

#region AggregateModels

using Account = CardPortal.Domain.AggregateModel.Account.Account;
using Card = CardPortal.Domain.AggregateModel.Card.Card;
using Transaction = CardPortal.Domain.AggregateModel.Transaction.Transaction;
using User = CardPortal.Domain.AggregateModel.User.User;
using Vendor = CardPortal.Domain.AggregateModel.Vendor.Vendor;
using Address = CardPortal.Domain.AggregateModel.Vendor.Address.Address.Address;
using Area = CardPortal.Domain.AggregateModel.Vendor.Address.Area.Area;
using City = CardPortal.Domain.AggregateModel.Vendor.Address.City.City;
using Contact = CardPortal.Domain.AggregateModel.Vendor.Contact.Contact.Contact;
using ContactType = CardPortal.Domain.AggregateModel.Vendor.Contact.ContactType.ContactType;
using CardPortal.Persistence.Configuration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

#endregion AggregateModels

namespace CardPortal.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Data - For Testing
            // new AppDbContextInitializer(modelBuilder).SeedData();
        }

        // Tables
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Area> Areas { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactType>  ContactTypes { get; set; }
    }
}
