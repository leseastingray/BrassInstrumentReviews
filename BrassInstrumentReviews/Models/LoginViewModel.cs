using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrassInstrumentReviews.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "A username is required.")]
        [StringLength(200)]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "A password is required.")]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
