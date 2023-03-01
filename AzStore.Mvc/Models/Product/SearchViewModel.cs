using AzStore.Mvc.Models.Search;
using AzStore.Mvc.Models.ShoppingCart;
using System.Diagnostics.CodeAnalysis;

namespace AzStore.Mvc.Models.Product
{
    [ExcludeFromCodeCoverage]
    public class SearchViewModel
    {
        public SearchResultsViewModel SearchResultsViewModel { get; }

        public ShoppingCartViewModel ShoppingCartViewModel { get; }

        public SearchFilterViewModel SearchFilterViewModel { get; }

        public SearchViewModel(SearchResultsViewModel searchResultsViewModel, ShoppingCartViewModel shoppingCartViewModel, SearchFilterViewModel searchFilterViewModel)
        {
            SearchResultsViewModel = searchResultsViewModel;
            ShoppingCartViewModel = shoppingCartViewModel;
            SearchFilterViewModel = searchFilterViewModel;
        }
    }
}