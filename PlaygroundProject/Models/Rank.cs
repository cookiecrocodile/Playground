using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlaygroundProject.Models
{
    public class Rank
    {
        public int Id { get; set; }


        [Index(IsUnique = true)]
        [Required(ErrorMessage="Rank must have a name")]
        [MinLength(2, ErrorMessage ="Rank name must have at least two characters")]
        [RegularExpression("^[a-zåäöA-ZÅÄÖ]+( [a-zåäöA-ZÅÄÖ]+)*$", ErrorMessage = "Name may only contain alphabetical characters")]
        public string RankName { get; set; }


    }
}