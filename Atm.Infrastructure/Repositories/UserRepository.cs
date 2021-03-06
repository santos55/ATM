﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atm.Model.Entities;
using Atm.DataHelpers;

namespace Atm.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        
        }

    }

    public interface IUserRepository : IRepository<User>
    {
        
    }
}
