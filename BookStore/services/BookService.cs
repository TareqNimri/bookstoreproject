using BookStore.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class BookService:IBookService
    {
        BookStoreContext bookStoreContext;
        public BookService(BookStoreContext _bookStoreContext)
        {
            bookStoreContext = _bookStoreContext;
        }

        public List<Book> LoadBooks()
        {
            List<Book> libook = bookStoreContext.books.ToList();
            foreach (Book item in libook)
            {
                item.categories = bookStoreContext.categories.Where(c => c.Id == item.Cat_Id).FirstOrDefault();
                item.authors= bookStoreContext.authors.Where(c => c.Id == item.Auth_Id).FirstOrDefault();

            }
            return libook;
        }
        public void InsertBook(Book book)
        {
            bookStoreContext.books.Add(book);
            bookStoreContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Book book=  bookStoreContext.books.Find(id);
            bookStoreContext.books.Remove(book);
            bookStoreContext.SaveChanges();
        }

        public Book Edit(int id)
        {
            Book book = bookStoreContext.books.Find(id);
            return book;
        }
        public void Update(Book book)
        {
            bookStoreContext.books.Attach(book);
            bookStoreContext.Entry(book).State = EntityState.Modified;
            bookStoreContext.SaveChanges();
        }
        
    }
}
