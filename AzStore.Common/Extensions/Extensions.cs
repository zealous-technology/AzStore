using System.Linq;

namespace AzStore.Common.Extensions
{
    public static class Extensions
    {
        public static IQueryable<T> Filter<T>(this IQueryable<T> collection, IFilter<T> filter, ISearchFilter search) where T : class
        {
            return filter.Filter(collection, search);
        }
    }
}