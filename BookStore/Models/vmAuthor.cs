using BookStore.data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class vmAuthor
    {
       
        public Author author { set; get; }
        public List<Author> authors { set; get; }
        public List<Nationality> nationalities { set; get; }
    }
}
