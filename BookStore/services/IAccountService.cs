using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
   public interface IAccountService
    {
        Task<IdentityResult> CreateUser(SignUpModel signUpModel);
        Task<SignInResult> CheckPassword(SignInModel signInModel);
        Task<IdentityResult> SaveRole(RoleModel roleModel);
        List<IdentityRole> GetRoles();
        Task Logout();
    }
}
