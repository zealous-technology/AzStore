using System.Collections.Generic;
using System.Linq;
using AzStore.Common;

namespace AzStore.Mvc.Models.Product
{
    public class SearchResultsViewModel
    {
        public IEnumerable<ProductViewModel> Products { get; }

        public string ProductCount => string.Format("({0} {1})", Products.Count(), Products.Count() == 1 ? "result" : "results");

        public SearchResultsViewModel(IEnumerable<IProduct> products)
        {
            Products = products.Select(p => new ProductViewModel(p));
        }
    }
}