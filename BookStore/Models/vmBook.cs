using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class vmBook
    {
        public Book book { set; get; }
        public List<Book> books { set; get; }
        public List<Author> liauthors { set; get; }
        public List<Category> licategories { set; get; }
    }
}
