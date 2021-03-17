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
    public class ReviewsAPIController : ControllerBase
    {
        private InstrumentReviewContext context;

        public ReviewsAPIController(InstrumentReviewContext context)
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
            if (review == null)
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
        public IActionResult AddReview([FromBody] ReviewViewModel reviewVM)
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
        // Replace/Put
        [HttpPut("{id}")]
        public IActionResult Replace(int id, [FromBody] ReviewViewModel reviewVM)
        {
            if (reviewVM != null)
            {
                Review review = context.Reviews.Find(id);
                review.InstrumentName = reviewVM.InstrumentName;
                review.InstrumentType = reviewVM.InstrumentType;
                review.Rating = reviewVM.Rating;
                review.ReviewText = reviewVM.ReviewText;
                review.ReviewDate = DateTime.Parse(reviewVM.ReviewDate);
                context.Update(review);
                return Ok(review);
            }
            else
            {
                return BadRequest();
            }
        }
        // Update/PATCH
        [HttpPatch("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] PatchViewModel patchVM)
        {
            Review review = context.Reviews.Find(id);
            switch (patchVM.Path)
            {
                case "name":
                    review.InstrumentName = patchVM.Value;
                    break;
                case "type":
                    review.InstrumentType = patchVM.Value;
                    break;
                case "text":
                    review.ReviewText = patchVM.Value;
                    break;
                case "date":
                    review.ReviewDate = Convert.ToDateTime(patchVM.Value);
                    break;
                default:
                    return BadRequest();
            }
            context.Update(review);
            return Ok(review);
        }
        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            Review review = context.Reviews.Find(id);
            if (review != null)
            {
                context.Reviews.Remove(review);
                context.SaveChanges();
                return NoContent();  // Successfully completed, no data to send back
            }
            else
            {
                return NotFound();
            }
        }
    }
}
