using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BrassInstrumentReviews.Models
{
    public class AdminViewModel
    {
        // Holds collection of Reviewer objects
        public IEnumerable<Reviewer> Reviewers { get; set; }
        // Holds collection of Role objects
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
