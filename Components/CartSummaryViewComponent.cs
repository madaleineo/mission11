using System;
using Microsoft.AspNetCore.Mvc;
using onlinebookstore.Models;

namespace onlinebookstore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Basket basket;

        public CartSummaryViewComponent(Basket b)
        {
            basket = b;
        }
        public IViewComponentResult Invoke()
        {
            return View(basket);
        }
    }
}
