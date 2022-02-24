using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using onlinebookstore.Models;

namespace onlinebookstore.Components
{
    public class TypesViewComponent : ViewComponent
    {
        private IOnlineBookstoreRepository repo { get; set; }

        public TypesViewComponent (IOnlineBookstoreRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var types = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(types);
        }
    }
}
