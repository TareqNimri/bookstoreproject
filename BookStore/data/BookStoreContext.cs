using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    
   
    public class BookStoreContext:IdentityDbContext<ApplicationUser>
    {
        IConfiguration Config;
        public BookStoreContext(IConfiguration _Config)
        {
            Config = _Config;
        }
        public DbSet<Nationality> nationalities { set; get; }
        public DbSet<Author> authors { set; get; }
        public DbSet<Book> books { get; set; }
        public DbSet<Category> categories { set; get; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.GetConnectionString("BookStoreConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
