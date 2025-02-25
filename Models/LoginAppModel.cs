using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Login.Models
{
    public class LoginAppModel
    {
        [Required(ErrorMessage = "Invalid Username")]
        [StringLength(15, MinimumLength = 4)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter a valid password")]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        [RegularExpression(@"^\\d+$")]
        public string Password { get; set; }
    }
}