using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    [Table("Books")]
    public class Book
    {
        public int Id { get; set; }
        [Required]
        public string  Title { get; set; }
        public int? Year { get; set; }
        [ForeignKey("Categories")]
        public int Cat_Id { get; set; }
        [ForeignKey("Authors")]
        public int Auth_Id { get; set; }
        public Category categories { get; set; }
        public Author authors { set; get; }

        [NotMapped]
        public IFormFile Image { set; get; }

        public string ImagePath { set; get; }
        public int Stock { get; set; }
        public double? Price { set; get; }

    }
}
