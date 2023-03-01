using System;
using System.Web.Mvc;
using System.Net;
using AzStore.Common;
using AzStore.Mvc.Models.Search;
using AzStore.Mvc.Models.ShoppingCart;

namespace AzStore.Mvc.Controllers
{
    public class ShoppingCartController : BaseController
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductService _productService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, IProductService productService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
        }
        
        public ActionResult AddToCart(Guid id)
        {
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = _productService.GetProduct(id);

            if (product == null)
                return HttpNotFound();

            ShoppingCart.Add(product);

            return PartialView("~/Views/Shared/ShoppingCart.cshtml", new ShoppingCartViewModel(ShoppingCart));
        }

        public ActionResult RemoveFromCart(Guid id)
        {
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = _productService.GetProduct(id);

            if (product == null)
                return HttpNotFound();

            ShoppingCart.Remove(product);

            return PartialView("~/Views/Shared/ShoppingCart.cshtml", new ShoppingCartViewModel(ShoppingCart));
        }
       
        public ActionResult Checkout()
        {
            if(_shoppingCartService.Checkout(ShoppingCart))
            {
                return View(new SearchFilterViewModel());
            }

            return RedirectToAction("Search", "Product");
        }
    }
}