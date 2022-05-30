using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    [Table("Nationalities")]
    public class Nationality
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Author> authors { set; get; }
    }
}
