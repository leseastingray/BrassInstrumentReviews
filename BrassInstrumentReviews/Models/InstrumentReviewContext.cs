using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassInstrumentReviews.Models
{
    public class InstrumentReviewContext : DbContext
    {
        public InstrumentReviewContext(DbContextOptions<InstrumentReviewContext> options) : base(options) { }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }
    }
}
