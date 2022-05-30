using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    [Table("Authors")]
    public class Author
    {

        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        public Nationality nationalities { get; set; }
        [ForeignKey("Nationalities")]
        public int Nat_Id { get; set; }
        [NotMapped]
        public IFormFile Image { set; get; }

        public string ImagePath { set; get; }
       public List<Book> books { set; get; }
    }
}
