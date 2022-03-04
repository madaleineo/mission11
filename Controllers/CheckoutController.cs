using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using onlinebookstore.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace onlinebookstore.Controllers
{
    public class CheckoutController : Controller
    {

        private ICheckoutRepository repo { get; set; }

        private Basket basket { get; set; }

        public CheckoutController(ICheckoutRepository temp)
        {
            repo = temp;
        }


        // GET: /<controller>/
        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Checkout());
        }

        [HttpPost]
        public IActionResult Checkout(Checkout checkout)
        {
            if (basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry your basket is empty!");
            }

            if (ModelState.IsValid)
            {
                checkout.Lines = basket.Items.ToArray();
                repo.SaveCheckout(checkout);
                basket.ClearBasket();

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
