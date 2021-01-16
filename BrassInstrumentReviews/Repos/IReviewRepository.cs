using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrassInstrumentReviews.Models;

namespace BrassInstrumentReviews.Repos
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }  // Read (or retrieve) reviews
        void AddReview(Review review);  // Create a review
    }
}
