using AzStore.Common.Model;
using System.Diagnostics.CodeAnalysis;

namespace AzStore.Mvc.Models.Search
{
    [ExcludeFromCodeCoverage]
    public class SearchFilterViewModel
    {
        public string Name { get; set; }

        public static explicit operator SearchFilter(SearchFilterViewModel model)
        {
            return new SearchFilter(model.Name);
        }
    }
}