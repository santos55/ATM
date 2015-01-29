using Atm.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Atm.DataHelpers
{
    public interface IDatabaseFactory : IDisposable
    {
        AtmContext Get();
    }
}
