using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace onlinebookstore.Models
{
    public interface IOnlineBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}

