using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atm.Services.Responses
{
    public class BalanceStatus
    {
        public string CardNumber { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
