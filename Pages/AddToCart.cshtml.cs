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

        public AddToCartModel (IOnlineBookstoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }


        public Basket basket { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book blah = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            basket.AddItem(blah, 1);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
