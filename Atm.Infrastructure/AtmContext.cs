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
            base.Seed(context);

            //Create User
            var user1 = new User { Name = "First User", Description = "User 1" };
            var user2 = new User { Name = "Second User", Description = "User 2"};
            var user3 = new User { Name = "Third User", Description = "User 3" };
            
            context.Users.Add(user1);
            context.Users.Add(user2);
            context.Users.Add(user3);

            ////Create Accounts
            var acc1 = new Account { Description = "First Account", Balance = 1000, User = user1 };
            var acc2 = new Account { Description = "Second Account", Balance = 80, User = user2 };
            var acc3 = new Account { Description = "Third Account", Balance = -1000, User = user3 };

            context.Accounts.Add(acc1);
            context.Accounts.Add(acc2);
            context.Accounts.Add(acc3);

            //Cards
            var card1 = new Card { Account = acc1, Blocked = false, Number = "1111111111111111", WrongAttempts = 0, Pin = "1111" };
            var card2 = new Card { Account = acc2, Blocked = true, Number = "2222222222222222", WrongAttempts = 4, Pin = "2222" };
            var card3 = new Card { Account = acc3, Blocked = false, Number = "3333333333333333", WrongAttempts = 0, Pin = "3333" };

            context.Cards.Add(card1);
            context.Cards.Add(card2);
            context.Cards.Add(card3);
            
            context.SaveChanges();
        }
    }
}

