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

    public class AtmContextInitializer : DropCreateDatabaseIfModelChanges<AtmContext>
    {
        protected override void Seed(AtmContext context)
        {
            
        }
    }
}
