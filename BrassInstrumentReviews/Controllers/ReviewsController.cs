using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrassInstrumentReviews.Models;

namespace BrassInstrumentReviews.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private InstrumentReviewContext context;

        public ReviewsController(InstrumentReviewContext context)
        {
            this.context = context;
        }

        /* action methods */
        // GET Reviews
        [HttpGet]
        public IActionResult GetReviews()
        {
            var reviews = context.Reviews.ToList();

            if (reviews.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(reviews);
            }
        }
        // GET a Review - Api/Review
        [HttpGet("{id}")]
        public IActionResult GetReview(int id)
        {
            var review = context.Reviews.Find(id);
            if (review ==  null)
            {
                return NotFound();
            }
            else
            {
                return Ok(review);
            }
        }
    }
}
