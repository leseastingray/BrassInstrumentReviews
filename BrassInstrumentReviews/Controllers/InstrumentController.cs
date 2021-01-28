using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BrassInstrumentReviews.Models;


namespace BrassInstrumentReviews.Controllers
{
    public class InstrumentController : Controller
    {
        private InstrumentReviewContext context { get; set; }
        public InstrumentController (InstrumentReviewContext cxt)
        {
            context = cxt;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Instrument Reviews";
            return View();
        }
        // Method to get a list of instrument reviews
        public IActionResult Reviews()
        {
            // Get all reviews in the database and order by instrument type
            //List<Review> reviews = repo.Reviews.ToList<Review>(); // Use ToList to convert the IQueryable to a list
            var reviews = context.Reviews.OrderBy(r => r.InstrumentType).ToList();
            return View(reviews);
        }
        public IActionResult ReviewsByName()
        {
            // Get all reviews in the database and order by reviewer name
            var reviews = context.Reviews.OrderBy(r => r.ReviewerName).ToList();
            return View("Reviews", reviews);
        }   
        public IActionResult ReviewsByRating()
        {
            // Get all reviews in the database and order by rating
            var reviews = context.Reviews.OrderBy(r => r.Rating).ToList();
            return View("Reviews", reviews);
        }
        public IActionResult FindReviewById()
        {
            // declare and instantiate id
            int id = 1;
            // find first review matching the review id
            var review = context.Reviews.Where(r => r.ReviewID == id).FirstOrDefault();
            return View(review);
        }
        /*
         * Method to search reviews for instrument name (probably using wildcard, if possible)
        // Method to filter reviews by instrument type
        [HttpPost]
        public IActionResult FilterReviews(string instrumentType)
        {
            List<Review> reviews = null;

            if (instrumentType!= null)
            {
                reviews = (from r in repo.Reviews
                           where r.InstrumentType == instrumentType
                           select r).ToList();
            }

            return View(reviews);
        }
        */
        // Method to get instrument review form
        [HttpGet]
        public IActionResult Review()
        {
            return View();
        }
        // Method to submit form and add new instrument review (see page 477 for DB context-related info)
        [HttpPost]
        public IActionResult Review(Review review)
        {
            // Timestamp
            //model.ReviewDate = DateTime.Now;
            /*
             *     Code to connect Reviewer object with Review object
             // Get the Reviewer object for the current user
             model.Reviewer = userManager.GetUserAsync(User).Result;
             // TODO: modify the register code to get the user's name
             model.Reviewer.Name = model.Reviewer.UserName;  // Temporary hack
             model.ReviewDate = DateTime.Now;
             // Store the model in the database
             repo.AddReview(model);
             return View(model);
             */

            // Store the model in the database
            if (ModelState.IsValid)
            {
                //repo.AddReview(model);
                context.Add(review);
                context.SaveChanges();
                return View("Index");
            }
            else
            {
                return View("Review");
            }
        }
        [HttpGet]
        public IActionResult EditReview(int id)
        {
            // Gets the Appropriate Review Details Page
            var review = context.Reviews.Find(id);
            return View(review);
        }
        [HttpPost]
        public IActionResult EditReview(Review review)
        {
            // Method to edit reviews, adds to the context/repo
            if (ModelState.IsValid)
            {
                context.Reviews.Update(review);
                context.SaveChanges();
                return RedirectToAction("Reviews", "Instrument");
            }
            else
            {
                return View(review);
            }
        }
        [HttpGet]
        public IActionResult DeleteReview(int id)
        {
            // Gets the appropriate Delete page by id
            var review = context.Reviews.Find(id);
            return View(review);
        }
        [HttpPost]
        public IActionResult DeleteReview(Review review)
        {
            // Method to delete reviews
            context.Reviews.Remove(review);
            context.SaveChanges();
            return RedirectToAction("Reviews", "Instrument");
        }
    }
}
