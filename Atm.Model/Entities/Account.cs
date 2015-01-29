using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Atm.Model.Entities
{
    public class Account
    {
        [Required]
        public int AccountId { get; set; }
        [Required]
        public double Balance { get; set; }
        public string Description { get; set; }
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }

}
