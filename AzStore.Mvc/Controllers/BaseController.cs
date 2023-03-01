using System.Web.Mvc;
using AzStore.Common.Model;

namespace AzStore.Mvc.Controllers
{
    public class BaseController : Controller
    {
        protected ProductShoppingCart ShoppingCart
        {
            get
            {
                if(Session["ShoppingCart"] == null)
                {
                    Session.Add("ShoppingCart", new ProductShoppingCart());
                }

                return (ProductShoppingCart)Session["ShoppingCart"];
            }
        }
    }
}