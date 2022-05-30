using BookStore.data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    
    public class AuthorService:IAuthorService
    {
        BookStoreContext bookStoreContext;
        public AuthorService(BookStoreContext _bookStoreContext)
        {
            bookStoreContext = _bookStoreContext;
        }
        public List<Author> LoadAuthors()
        {
            List<Author> authli = bookStoreContext.authors.ToList();
            return authli;
        }
        public void InsertAuthor(Author author)
        {
            bookStoreContext.authors.Add(author);
            bookStoreContext.SaveChanges();

        }
        public void Delete(int id)
        {
            
           Author author = bookStoreContext.authors.Find(id);
            bookStoreContext.authors.Remove(author);
            bookStoreContext.SaveChanges();
        }
        public Author Edit(int id)
        {
            Author author = bookStoreContext.authors.Find(id);
            return author;
        }
        public void Update(Author author)
        {
            bookStoreContext.authors.Attach(author);
            bookStoreContext.Entry(author).State = EntityState.Modified;
            bookStoreContext.SaveChanges();
        }
    }
}
