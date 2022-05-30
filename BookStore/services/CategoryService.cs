using BookStore.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{

    public class CategoryService:ICategoryService
    {
        BookStoreContext bookStoreContext;
        public CategoryService(BookStoreContext _bookStoreContext)
        {
            bookStoreContext = _bookStoreContext;
        }
        public List<Category> LoadCategories()
        {
            List<Category> catgli = bookStoreContext.categories.ToList();
            return catgli;
        }
        public void InsertCategory(Category category)
        {
            bookStoreContext.Add(category);
            bookStoreContext.SaveChanges();

        }
        public void Delete(int id)
        {
            Category category = bookStoreContext.categories.Find(id);
            bookStoreContext.categories.Remove(category);
            bookStoreContext.SaveChanges();
        }
        public Category Edit(int id)
        {
            Category category = bookStoreContext.categories.Find(id);
            return category;
        }

        public void Update(Category category)
        {
            bookStoreContext.categories.Attach(category);
            bookStoreContext.Entry(category).State = EntityState.Modified;
            bookStoreContext.SaveChanges();
        }
    }
}
