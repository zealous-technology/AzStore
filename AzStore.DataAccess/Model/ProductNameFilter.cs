using System.Linq;
using AzStore.Common;

namespace AzStore.DataAccess.Model
{
    public class ProductNameFilter : IFilter<ProductEntity>
    {
        public IQueryable<ProductEntity> Filter(IQueryable<ProductEntity> collection, ISearchFilter searchFilter)
        {
            if (collection == null)
                return Enumerable.Empty<ProductEntity>().AsQueryable();

            return string.IsNullOrEmpty(searchFilter?.Text)
                    ? collection
                    : collection.Where(p => p.Name.ToUpper().Contains(searchFilter.Text.ToUpper()));
        }
    }
}