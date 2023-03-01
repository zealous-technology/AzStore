using System.Web.Mvc;
using AzStore.Common;
using AzStore.Common.Model;
using AzStore.Mvc.Models.ShoppingCart;
using AzStore.Mvc.Models.Search;
using AzStore.Mvc.Models.Product;
using System.Net;

namespace AzStore.Mvc.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {           
            _productService = productService;
        }

        public ActionResult Search(SearchFilterViewModel model)
        {            
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var products = _productService.GetProducts((SearchFilter)model);

            return View(new SearchViewModel(new SearchResultsViewModel(products), new ShoppingCartViewModel(ShoppingCart), model));
        }
        
        public ActionResult Contact()
        {
            ViewData["Message"] = "Contact";

            return View(new SearchFilterViewModel());
        }
    }
}