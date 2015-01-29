using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Atm.Web.Models
{
    public class CardModel
    {
        [Required]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

    }

    public class PinModel
    {
        [Required]
        [Display(Name = "Card Number")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "PIN")]
        public string Pin { get; set; }
    }
}
