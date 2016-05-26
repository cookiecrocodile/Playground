using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlaygroundProject.Models
{
    public class Pawn
    {
        public int Id { get; set; }

        [Required (ErrorMessage = "Amount of hp is required")]
        //[RegularExpression("^[0-9]+$", ErrorMessage = "You may only enter numbers")]
        public int Hp { get; set; }

        [Required(ErrorMessage = "Type of pawn is required")]
        [Index(IsUnique = true)]
        [MinLength(1, ErrorMessage ="Type must be at least 1 character long")]
        [RegularExpression("^[a-zåäöA-ZÅÄÖ]+( [a-zåäöA-ZÅÄÖ]+)*$", ErrorMessage = "Name may only contain alphabetical characters")]
        public string Type { get; set; }

        //public virtual IList<Player> OwnedBy { get; set; }

       
    }
}