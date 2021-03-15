using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrassInstrumentReviews.Controllers
{
    public class CommentAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
