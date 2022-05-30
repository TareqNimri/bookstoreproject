using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
   public interface INationalityService
    {
        List<Nationality> LoadNation();
        void InsertNation(Nationality nationality);
        void Delete(int id);
         Nationality Edit(int id);
        void Update(Nationality nationality);
    }
}
