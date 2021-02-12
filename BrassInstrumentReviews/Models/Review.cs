using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrassInstrumentReviews.Models
{
    public class Review
    {
        // ID for EF Core primary key
        [Key]
        public int ReviewID { get; set; }

        // Declare and instantiate List field to hold associated Comment objects
        private List<Comment> comments = new List<Comment>();

        [Required(ErrorMessage = "The instrument name is required.")]
        [StringLength(200, MinimumLength = 3,
            ErrorMessage = "Instrument name must be between 3 and 200 characters.")]
        public string InstrumentName { get; set; }
        public string InstrumentType { get; set; }
        [Range(0,5,ErrorMessage ="Select an instrument rating.")]
        // 0 = worst, 1 = bad, 2 = okay, 3 = good, 4 = great,  5 = best
        public int? Rating { get; set; }
        public string ReviewText { get; set; }

        // Changed to take Reviewer class object, might need to comment out validation annotations
        [Required(ErrorMessage = "The reviewer name is required.")]
        //[StringLength(40, MinimumLength = 3, ErrorMessage = "Reviewer name must be between 3 and 40 characters.")]
        //public string ReviewerName { get; set; }
        public Reviewer Reviewer { get; set; }

        // Not a timestamp currently
        [Required(ErrorMessage = "The review date is required.")]
        public DateTime ReviewDate { get; set; }

        // Get List holding associated Comment objects
        public List<Comment> Comments
        {
            get { return comments; }
        }
    }
}
