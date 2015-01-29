using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Atm.Model.Entities
{
    public class User 
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Name Required")]        
        [MaxLength(255)]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
    }

}
