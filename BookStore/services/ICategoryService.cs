using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
   public interface ICategoryService
    {
        List<Category> LoadCategories();
        void InsertCategory(Category category);
        void Delete(int id);
        Category Edit(int id);
        void Update(Category category);
    }
}
