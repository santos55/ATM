using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atm.Model.Entities;
using Atm.DataHelpers;

namespace Atm.Infrastructure.Repositories
{
    public class OperationRepository : RepositoryBase<Operation>, IOperationRepository
    {
        public OperationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        
        }

    }

    public interface IOperationRepository : IRepository<Operation>
    {
        
    }
}
