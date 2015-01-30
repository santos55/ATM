using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atm.Web.Models
{
    public class BalanceModel
    {
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Amount")]
        public double Amount { get; set; }
    }

}
