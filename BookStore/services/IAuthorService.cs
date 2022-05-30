using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public interface IAuthorService
    {
        List<Author> LoadAuthors();
        void InsertAuthor(Author author);
        public void Delete(int id);
        Author Edit(int id);
        void Update(Author author);
    }
}
