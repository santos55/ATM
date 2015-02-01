using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atm.Web.Models
{
    public class WithdrawalModel
    {     
        [Required]
        [Display(Name = "Amount")]     
        [Range(1, 10000)]
        public double Amount { get; set; }

    }

    public class WithdrawalReportModel
    {
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Withdrawal Amount")]
        public double Amount { get; set; }

        [Display(Name = "Balance")]
        public double Balance { get; set; }


    }


}
