using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BrassInstrumentReviews.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "A username is required.")]
        [StringLength(200)]
        public string Username { get; set; }

        [Required(ErrorMessage = "A password is required.")]
        // Labeling as password datatype facilitates password validation via Startup.cs
        [DataType(DataType.Password)]
        // Compares and checks if entered passwords match
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You must confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
