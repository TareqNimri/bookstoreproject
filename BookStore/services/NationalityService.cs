using BookStore.data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    
    public class NationalityService:INationalityService
    {
        BookStoreContext bookStoreContext;
        public NationalityService(BookStoreContext _bookStoreContext)
        {
            bookStoreContext = _bookStoreContext;
        }
       public List<Nationality> LoadNation()
        {
            List<Nationality> natli = bookStoreContext.nationalities.ToList();

            return natli;
        } 
        public void InsertNation(Nationality nationality)
        {
            bookStoreContext.Add(nationality);
            bookStoreContext.SaveChanges();

        }
        public void Delete(int id)
        {
            Nationality nationality = bookStoreContext.nationalities.Find(id);
            bookStoreContext.nationalities.Remove(nationality);
            bookStoreContext.SaveChanges();
        }
        public Nationality Edit(int id)
        {
            Nationality nationality = bookStoreContext.nationalities.Find(id);
            return nationality;
        }
        public void Update(Nationality nationality)
        {
            bookStoreContext.nationalities.Attach(nationality);
            bookStoreContext.Entry(nationality).State = EntityState.Modified;
            bookStoreContext.SaveChanges();
            
        }
    }
}
