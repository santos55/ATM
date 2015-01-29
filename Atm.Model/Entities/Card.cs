using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Atm.Model.Entities
{
    public class Card
    {
        [Required]
        public int CardId { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public int WrongAttempts { get; set; }
        [Required]
        public bool Blocked { get; set; }
        [Required]
        public string Pin { get; set; }
        [Required]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
    }

}
