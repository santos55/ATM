using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atm.Model.Entities;
using Atm.DataHelpers;

namespace Atm.Infrastructure.Repositories
{
    public class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
        public Card GetByNumber(string number)
        {
            return this.DataContext.Cards.SingleOrDefault(c=>c.Number == number);
        }       

    }

    public interface ICardRepository : IRepository<Card>
    {

        Card GetByNumber(string number);
    }
}
