using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class vmCategory
    {
        public Category category { set; get; }
        public List<Category> categories { set; get; }
    }
}
