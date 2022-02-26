using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using onlinebookstore.Infrastructure;
using onlinebookstore.Models;

namespace onlinebookstore.Pages
{
    public class AddToCartModel : PageModel
    {
        private IOnlineBookstoreRepository repo { get; set; }

        public AddToCartModel (IOnlineBookstoreRepository temp)
        {
            repo = temp;
        }


        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {

            ReturnUrl = returnUrl ?? "/";
            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket ();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book blah = repo.Books.FirstOrDefault(x => x.BookId == bookId);


            basket = HttpContext.Session.GetJson<Basket>("basket") ?? new Basket();
            basket.AddItem(blah, 1);

            HttpContext.Session.SetJson("basket", basket);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
