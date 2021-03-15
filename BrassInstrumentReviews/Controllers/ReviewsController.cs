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
        // POST Review
        [HttpPost]
        public IActionResult AddReview([FromBody]ReviewViewModel reviewVM)
        {
            if (reviewVM != null)
            {
                Reviewer reviewPerson = new Reviewer
                {
                    UserName = reviewVM.ReviewerUserName,
                    Name = reviewVM.ReviewerName
                };
                Review review = new Review
                {
                    InstrumentName = reviewVM.InstrumentName,
                    InstrumentType = reviewVM.InstrumentType,
                    Rating = reviewVM.Rating,
                    ReviewText = reviewVM.ReviewText,
                    ReviewDate = DateTime.Parse(reviewVM.ReviewDate)
                };
                context.Users.Add(reviewPerson);
                context.SaveChanges();   // This will add a UserID to the reviewer object              
                context.Reviews.Add(review);
                context.SaveChanges();
                return Ok(review);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
