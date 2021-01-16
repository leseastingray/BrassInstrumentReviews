using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrassInstrumentReviews.Models
{
    public class Reviewer
    {
        // ID for EF Core primary key
        public int ReviewerID { get; set; }
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name must contain 3 to 60 characters.")]
        [Required]
        public string Name { get; set; }
        public string PrimaryInstrument { get; set; }
    }
}
