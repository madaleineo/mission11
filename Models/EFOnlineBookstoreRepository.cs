using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinebookstore.Models
{
    public class EFOnlineBookstoreRepository : IOnlineBookstoreRepository
    {
        private BookstoreContext context { get; set; }

        public EFOnlineBookstoreRepository(BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Book> Books => context.Books;

        public void SaveBook(Book b)
        {
            context.SaveChanges();
        }

        public void CreateBook(Book b)
        {
            context.Add(b);
            context.SaveChanges();
        }

        public void DeleteProject(Book b)
        {
            context.Remove(b);
            context.SaveChanges();
        }
    }
}
