using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atm.Model.Entities;
using Atm.DataHelpers;

namespace Atm.Infrastructure.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        
        }

    }

    public interface IAccountRepository : IRepository<Account>
    {
       
    }
}
