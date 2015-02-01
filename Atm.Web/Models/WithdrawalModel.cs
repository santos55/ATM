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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        [DataType(DataType.Currency)]
        [Range(0, 10000)]
        public double Amount { get; set; }

    }

    public class WithdrawalReportModel
    {
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "WithdrawalAmount")]
        public double Amount { get; set; }

        [Display(Name = "Balance")]
        public double Balance { get; set; }


    }


}
