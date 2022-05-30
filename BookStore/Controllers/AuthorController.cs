using BookStore.data;
using BookStore.Models;
using BookStore.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AuthorController : Controller
    {
        IConfiguration Config;
        INationalityService nationalityService;
        IAuthorService authorService;

        public AuthorController(IConfiguration _Config, INationalityService _nationalityService,IAuthorService _authorService)
        {
            Config = _Config;
            nationalityService = _nationalityService;
            authorService = _authorService;

        }
       
        public IActionResult Index(vmAuthor vm)
        {
            ViewData["IsEdited"] = false;
            vm.authors = authorService.LoadAuthors();
            vm.nationalities = nationalityService.LoadNation();

            return View("NewAuthor",vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(vmAuthor vm)
        {
            ViewData["IsEdited"] = false;
            string name = Guid.NewGuid().ToString() + "." + vm.author.Image.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Uploadimages", name);
            vm.author.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.author.ImagePath = "http://localhost/BookStore/StaticPath" + "/" + name;
            
            authorService.InsertAuthor(vm.author);
            vm.authors = authorService.LoadAuthors();
            vm.nationalities = nationalityService.LoadNation();
            return View("NewAuthor",vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAuthor(vmAuthor vm, int id)
        {
            ViewData["IsEdited"] = false;
            authorService.Delete(id);
            vm.authors = authorService.LoadAuthors();
            vm.nationalities = nationalityService.LoadNation();


            return View("NewAuthor",vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(vmAuthor vm,int id)
        {
            ViewData["IsEdited"] = true;
            vm.author = authorService.Edit(id);
            vm.authors = authorService.LoadAuthors();
            vm.nationalities = nationalityService.LoadNation();
            return View("NewAuthor", vm);
        }

        public IActionResult Update(vmAuthor vm)
        {
            ViewData["IsEdited"] = false;

            authorService.Update(vm.author);
            vm.authors = authorService.LoadAuthors();
            vm.nationalities = nationalityService.LoadNation();
            return View("NewAuthor", vm);
        }

    }
}
