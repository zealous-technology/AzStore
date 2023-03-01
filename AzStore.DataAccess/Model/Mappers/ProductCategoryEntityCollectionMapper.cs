using System.Collections.Generic;
using System.Linq;
using AzStore.Common;
using AzStore.Common.Model;

namespace AzStore.DataAccess.Model.Mappers
{
    public class ProductCategoryEntityCollectionMapper : IEntityCollectionMapper<IProductCategory, ProductCategoryEntity>
    {
        public IEnumerable<IProductCategory> Map(IEnumerable<ProductCategoryEntity> items)
        {
            return items.Select(c => new ProductCategory(c.Id, c.Name));
        }
    }
}