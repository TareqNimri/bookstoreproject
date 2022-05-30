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
    public class BookController : Controller
    {
        IConfiguration Config;
        ICategoryService categoryService;
        IAuthorService authorService;
        IBookService bookService;
        public BookController(IConfiguration _Config, ICategoryService _categoryService, IAuthorService _authorService,IBookService _bookService)
        {
            Config = _Config;
            categoryService = _categoryService;
            authorService = _authorService;
            bookService = _bookService;
        }
        public IActionResult Index(vmBook vm)
        {
            ViewData["IsEdited"] = false;
           
            vm.books=  bookService.LoadBooks();
          vm.liauthors=  authorService.LoadAuthors();
           vm.licategories= categoryService.LoadCategories();
            


            return View("NewBook",vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Save(vmBook vm)
        {
            ViewData["IsEdited"] = false;
            string name = Guid.NewGuid().ToString() + "." + vm.book.Image.FileName.Split('.')[1];
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Coverimages", name);
            vm.book.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.book.ImagePath = "http://localhost/BookStore/StaticPath" + "/" + name;

            bookService.InsertBook(vm.book);

            vm.books = bookService.LoadBooks();
            vm.liauthors = authorService.LoadAuthors();
            vm.licategories = categoryService.LoadCategories();



            return View("NewBook", vm);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteBook(vmBook vm,int id)
        {
            ViewData["IsEdited"] = false;
            bookService.Delete(id);
            vm.books = bookService.LoadBooks();
            vm.liauthors = authorService.LoadAuthors();
            vm.licategories = categoryService.LoadCategories();

            return View("NewBook", vm);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(vmBook vm,int id)
        {
            ViewData["IsEdited"] = true;

            vm.book = bookService.Edit(id);
            vm.books = bookService.LoadBooks();
            vm.liauthors = authorService.LoadAuthors();
            vm.licategories = categoryService.LoadCategories();

            return View("NewBook", vm);
        }
        public IActionResult Update(vmBook vm)
        {
            ViewData["IsEdited"] = false;

            bookService.Update(vm.book);

            vm.books = bookService.LoadBooks();
            vm.liauthors = authorService.LoadAuthors();
            vm.licategories = categoryService.LoadCategories();


            return View("NewBook", vm);
        }
    }
}
