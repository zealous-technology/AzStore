using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AzStore.Common;
using AzStore.Mvc.Models.Product;

namespace AzStore.Mvc.Models.ShoppingCart
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; }

        public string ProductCount => string.Format("({0} {1})", Products.Count(), Products.Count() == 1 ? "item" : "items");

        public bool DisableCheckout => !Products.Any();

        [DataType(DataType.Currency)]
        public decimal Total { get; }

        public ShoppingCartViewModel(IShoppingCart<IProduct> shoppingCart)
        {
            Products = shoppingCart.Items.Select(p => new ProductViewModel(p));
            Total = shoppingCart.Total;
        }
    }
}