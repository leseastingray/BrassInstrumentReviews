using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrassInstrumentReviews.Models;
using Microsoft.EntityFrameworkCore;

namespace BrassInstrumentReviews.Repos
{
    public class ReviewRepository : IReviewRepository
    {
        private InstrumentReviewContext context;

        // constructor
        public ReviewRepository(InstrumentReviewContext c)
        {
            context = c;
        }

        public IQueryable<Review> Reviews
        {
            get
            {
                // Get all the Review objects in the Reviews DbSet
                // and include the Reivewer object in each Review.
                return context.Reviews.Include(review => review.InstrumentType);
            }
        }

        public void AddReview(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
        }

    }
}
