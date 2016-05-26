using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlaygroundProject.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        [Required(ErrorMessage = "Player must have a name")]
        [MinLength(1, ErrorMessage ="Player name must be at least 1 character long")]
        [RegularExpression("^[a-zåäöA-ZÅÄÖ]+( [a-zåäöA-ZÅÄÖ]+)*$", ErrorMessage ="Name may only contain alphabetical characters")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Player must have  a rank")]
        public virtual Rank Rank { get; set; }

        public virtual IList<Pawn> Pawns { get; set; }
    }
}