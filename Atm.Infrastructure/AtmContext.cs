using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using Atm.Model.Entities;

namespace Atm.Infrastructure
{
    public class AtmContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public virtual void Commit()
        {
            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }

    public class AtmContextInitializer : CreateDatabaseIfNotExists<AtmContext>
    {
        protected override void Seed(AtmContext context)
        {

            //Create User
            var users = new List<User>();

            var user1 = new User { Name = "First User", Description = "User 1"};
            var user2 = new User { Name = "Second User", Description = "User 2"};
            var user3 = new User { Name = "Third User", Description = "User 3" };

            foreach (var u in users)
                context.Users.Add(u);

            //Create Accounts
            var accounts = new List<Account>();

            var acc1 = new Account { Description = "First Account", Balance = 1000, UserId = user1.UserId };
            var acc2 = new Account { Description = "Second Account", Balance = 1000, UserId = user2.UserId };
            var acc3 = new Account { Description = "Third Account", Balance = -1000, UserId = user3.UserId };

            foreach (var a in accounts)
                context.Accounts.Add(a);

            //Create cards
            var cards = new List<Card>();

            var card1 = new Card { AccountId = acc1.AccountId, Blocked = false, Number="1111-1111-1111-1111", WrongAttempts=0, Pin = "1111"};
            var card2 = new Card { AccountId = acc2.AccountId, Blocked = true, Number = "2222-2222-2222-2222", WrongAttempts = 4, Pin = "2222" };
            var card3 = new Card { AccountId = acc3.AccountId, Blocked = false, Number = "3333-3333-3333-3333", WrongAttempts = 0, Pin = "3333" };

            foreach (var a in cards)
                context.Cards.Add(a);

            base.Seed(context);
            context.SaveChanges();
        }
    }
}
