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
        [HttpGet]
        public IActionResult Review()
        {
            return View();
        }
        [HttpPost]
        // Method to add new bird sighting (see page 477 for DB context-related info)
        [HttpPost]
        public IActionResult AddReview(Review review)
        {
            // Validate model
            /* if (ModelState.IsValid)
            {
            } */
            return RedirectToAction("List", "Review");
        }
        // Method to update bird sighting
        // Method to delete bird sighting
    }
}
