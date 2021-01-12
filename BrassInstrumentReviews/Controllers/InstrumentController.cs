using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            ViewBag.Title = "Instrument Reviews";
            return View();
        }
        // Method to get a list of instrument reviews
        public IActionResult Reviews()
        {
            // Get all reviews in the database
            //List<Review> reviews = repo.Reviews.ToList<Review>(); // Use ToList to convert the IQueryable to a list
            // var reviews = context.Reviews.Include(book => book.Reviewer).ToList<Review>();
            return View(/*reviews*/);
        }
        /*
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
        public IActionResult AddReview(Review review)
        {
            // Validate model
            /* if (ModelState.IsValid)
            {
            } */
            return RedirectToAction("List", "Review");
        }
    }
}
