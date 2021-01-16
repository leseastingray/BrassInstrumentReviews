using BrassInstrumentReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassInstrumentReviews.Repos
{
    public class FakeReviewRepository : IReviewRepository
    {
        public IQueryable<Review> Reviews => throw new NotImplementedException();

        public void AddReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
