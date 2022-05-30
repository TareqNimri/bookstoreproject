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
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index(vmCategory vm)
        {
            ViewData["IsEdited"] = false;
            vm.categories = categoryService.LoadCategories();
            return View("CategoryList",vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult SaveCategory( vmCategory vm)
        {
            ViewData["IsEdited"] = false;
            categoryService.InsertCategory(vm.category);
            vm.categories = categoryService.LoadCategories();

            return View("CategoryList", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCat(vmCategory vm,int id)
        {
            ViewData["IsEdited"] = false;
            categoryService.Delete(id);
            vm.categories = categoryService.LoadCategories();
            return View("CategoryList", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(vmCategory vm,int id)
        {
            ViewData["IsEdited"] = true;
            vm.category = categoryService.Edit(id);
            vm.categories = categoryService.LoadCategories();
            return View("CategoryList", vm);
        }
        public IActionResult Update(vmCategory vm)
        {
            ViewData["IsEdited"] = false;
            categoryService.Update(vm.category);
            vm.categories = categoryService.LoadCategories();
            return View("CategoryList", vm);
        }
    }
}
