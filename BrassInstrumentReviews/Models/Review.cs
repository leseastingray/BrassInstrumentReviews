using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrassInstrumentReviews.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        [Required(ErrorMessage = "The instrument name is required.")]
        [StringLength(200, MinimumLength = 3,
            ErrorMessage = "Instrument name must be between 3 and 200 characters.")]
        public string InstrumentName { get; set; }
        [Required(ErrorMessage = "The instrument type is required.")]
        [StringLength(100, MinimumLength = 3, 
            ErrorMessage = "Instrument type must be between 3 and 100 characters.")]
        public string InstrumentType { get; set; }
        [Required(ErrorMessage = "An instrument rating is required.")]
        [Range(0, 5, ErrorMessage = "Rating must be an integer between 0 and 5 inclusive).")]
        // 0 = worst, 1 = bad, 2 = okay, 3 = good, 4 = great,  5 = best
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
