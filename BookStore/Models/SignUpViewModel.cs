using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class SignUpViewModel
    {
        public SignUpModel signUpModel { get; set; }
        public List<IdentityRole> liRoles { get; set; }
    }
}
