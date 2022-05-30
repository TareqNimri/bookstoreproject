using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    [Table("Categories")]
    public class Category
    {
        public int Id { get; set; }
        public string CategoryCode { get; set; }
        public string  Name { get; set; }
        public List<Book> books { set; get; }
    }
}
