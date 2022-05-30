using BookStore.data;
using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class NationalityController : Controller
    {
        INationalityService nationalityService;
        public NationalityController(INationalityService _nationalityService)
        {
            nationalityService = _nationalityService;
        }
        public IActionResult Index(vmNationality vm)
        {
            ViewData["IsEdited"] = false;
            vm.nationalities = nationalityService.LoadNation();

            return View("NewNationality",vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(vmNationality vm)
        {
            ViewData["IsEdited"] = false;
            nationalityService.InsertNation(vm.nationality);
            vm.nationalities = nationalityService.LoadNation();
            return View("NewNationality", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteNat(vmNationality vm,int id)
        {
            ViewData["IsEdited"] = false;

            nationalityService.Delete(id);
            vm.nationalities = nationalityService.LoadNation();
            return View("NewNationality",vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(vmNationality vm, int id)
        {
            ViewData["IsEdited"] = true;
            vm.nationality = nationalityService.Edit(id);
            vm.nationalities = nationalityService.LoadNation();

            return View("NewNationality",vm);
        }
        public IActionResult Update(vmNationality vm)
        {
            ViewData["IsEdited"] = false;
            nationalityService.Update(vm.nationality);
            vm.nationalities = nationalityService.LoadNation();
            return View("NewNationality", vm);
        }
    }
}
