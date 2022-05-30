using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
   public interface IBookService
    {
        List<Book> LoadBooks();
        void InsertBook(Book book);
        void Delete(int id);
        Book Edit(int id);
        void Update(Book book);
    }
}
