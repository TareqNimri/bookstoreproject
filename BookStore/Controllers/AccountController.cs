using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        IAccountService accountService;
        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
      
        public IActionResult Index()
        {
            SignUpViewModel vm = new SignUpViewModel();
           List<IdentityRole> liRole= accountService.GetRoles();
            vm.liRoles = liRole;
            return View("CreateAccount",vm);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAccount(SignUpViewModel signUpViewModel)
        {

            
            var result= await accountService.CreateUser(signUpViewModel.signUpModel);
            SignUpViewModel vm = new SignUpViewModel();
            List<IdentityRole> liRole = accountService.GetRoles();
            vm.liRoles = liRole;
            return View("CreateAccount",vm);
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> CheckPassword(SignInModel signInModel)
        {
           var result=await accountService.CheckPassword(signInModel);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["ErrorMessage"] = "Invalid username or password";
                return View("Login");
            }
        }
        [Authorize(Roles = "Admin")]
        public IActionResult NewRole()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public async Task <IActionResult> SaveRole(RoleModel roleModel)
        {
           var result= await accountService.SaveRole(roleModel);
            return View("NewRole");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task <IActionResult> Logout()
        {
            await accountService.Logout();
            return View("Login");
        }

    }
}
