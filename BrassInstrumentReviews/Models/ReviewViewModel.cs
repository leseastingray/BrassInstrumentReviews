using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassInstrumentReviews.Models
{
    // This model is for Api data
    public class ReviewViewModel
    {
        public int ReviewID { get; set; }
        public String InstrumentName { get; set; }
        public String InstrumentType { get; set; }
        public int Rating { get; set; }
        public String ReviewText { get; set; }
        // Reviewer's username
        public String ReviewerUserName { get; set; }
        // Reviewer's regular name
        public String ReviewerName { get; set; }
        public String ReviewDate { get; set; }
    }
}
