using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage ="Please enter your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter your Email")]
        public string Email { get; set; }
        [Compare("ConfirmPassword")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string RoleId { get; set; }
    }
}
