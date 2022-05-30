using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class vmNationality
    {
        public Nationality nationality { set; get; }
        public List<Nationality> nationalities { set; get; }
    }
}
