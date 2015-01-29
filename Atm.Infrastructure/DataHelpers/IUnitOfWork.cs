using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atm.DataHelpers
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
