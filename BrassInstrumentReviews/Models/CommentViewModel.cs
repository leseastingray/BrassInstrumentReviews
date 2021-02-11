using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassInstrumentReviews.Models
{
    public class CommentViewModel
    {
        public int ReviewID { get; set; }
        //public int InstrumentName { get; set; }

        // Temporary property to hold string name for commenter; later this will connect to Reviwer object
        public string CommenterName { get; set; }
        public string CommentText { get; set; }
    }
}
