using System.Linq;
using Microsoft.AspNetCore.Mvc;
using onlinebookstore.Models;
using onlinebookstore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace onlinebookstore.Controllers
{
    public class HomeController : Controller
    {
        private IOnlineBookstoreRepository repo;

        public HomeController(IOnlineBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1) // default set to one
        {
            int numResults = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookCategory || bookCategory == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * numResults)
                .Take(numResults),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (bookCategory == null
                            ? repo.Books.Count()
                            : repo.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = numResults,
                    CurrentPage = pageNum,
                }
            };

            return View(x);
        }

    }
}