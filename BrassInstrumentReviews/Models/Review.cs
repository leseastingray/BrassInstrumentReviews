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
        // 0 = worst, 1 = bad, 2 = okay, 3 = good, 4 = great,  5 = best
        public int? Rating { get; set; }
        public string ReviewText { get; set; }
        [Required(ErrorMessage = "A reviewer name is required.")]
        [StringLength(40, MinimumLength = 3,
            ErrorMessage = "Reviewer name must be between 3 and 40 characters.")]
        public string ReviewerName { get; set; }
        [Required(ErrorMessage = "The review date is required.")]
        public DateTime ReviewDate { get; set; }
    }
}
