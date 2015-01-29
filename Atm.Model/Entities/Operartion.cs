using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Atm.Model.Entities
{
    public class Operation
    {
        [Required]
        public int OperationId { get; set; }

        [Required]
        public int CardId { get; set; }
        public virtual Card Card { get; set; }
        [Required]
        public OperationTypes OpeartionType { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }

}
