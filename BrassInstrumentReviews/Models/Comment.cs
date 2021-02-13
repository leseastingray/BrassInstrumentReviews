using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrassInstrumentReviews.Models
{
    public class Comment
    {
        // Id for primary key in the database
        [Key]
        public int CommentID { get; set; }

        [Required(ErrorMessage = "Comment text is required.")]
        public string CommentText { get; set; }
        // For Comment timestamp
        public DateTime CommentDate { get; set; }
        // Temporary CommenterName, until time to hook up Reviewer object
        //public string CommenterName { get; set; }
        // Refers to Reviewer class object; each Comment can only be associated with one Reviewer
        public Reviewer Commenter { get; set; }

        // Refers to Review class object; each Comment can only be associated with one Review
        //public Review CommentReview { get; set; }
    }
}
