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
    public class CommentsAPIController : ControllerBase
    {
        private InstrumentReviewContext context;

        public CommentsAPIController(InstrumentReviewContext context)
        {
            this.context = context;
        }

        /* action methods */
        // GET Reviews
        [HttpGet]
        public IActionResult GetComments()
        {
            var reviews = context.Comments.ToList();

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
        public IActionResult GetComment(int id)
        {
            var review = context.Comments.Find(id);
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
        public IActionResult AddComment([FromBody] CommentViewModel commentVM)
        {
            if (commentVM != null)
            {
                Comment comment = new Comment
                {
                    CommentText = commentVM.CommentText,
                    CommentDate = DateTime.Today
                };
                context.Comments.Add(comment);
                context.SaveChanges();
                return Ok(comment);
            }
            else
            {
                return BadRequest();
            }
        }
        // Replace/Put
        [HttpPut("{id}")]
        public IActionResult Replace(int id, [FromBody] CommentViewModel commentVM)
        {
            if (commentVM != null)
            {
                Comment comment = context.Comments.Find(id);
                comment.CommentText = commentVM.CommentText;
                comment.CommentDate = DateTime.Today;
                context.Update(comment);
                return Ok(comment);
            }
            else
            {
                return BadRequest();
            }
        }
        // Update/PATCH
        [HttpPatch("{id}")]
        public IActionResult UpdateComment(int id, [FromBody] PatchViewModel patchVM)
        {
            Comment comment = context.Comments.Find(id);
            switch (patchVM.Path)
            {
                case "text":
                    comment.CommentText = patchVM.Value;
                    break;
                case "date":
                   comment.CommentDate = Convert.ToDateTime(patchVM.Value);
                    break;
                default:
                    return BadRequest();
            }
            context.Update(comment);
            return Ok(comment);
        }
        // Delete
        [HttpDelete("{id}")]
        public IActionResult DeleteReview(int id)
        {
            Comment comment = context.Comments.Find(id);
            if (comment != null)
            {
                context.Comments.Remove(comment);
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
