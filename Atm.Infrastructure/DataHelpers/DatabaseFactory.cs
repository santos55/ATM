using Atm.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atm.DataHelpers
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private AtmContext dataContext;
        public AtmContext Get()
        {
            return dataContext ?? (dataContext = new AtmContext());
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}
