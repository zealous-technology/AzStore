using System;
using System.Collections.Generic;

namespace AzStore.Common
{
    public interface IRepository
    {
        IEnumerable<IProductCategory> GetProductCategories();
        IEnumerable<IProduct> GetProducts(ISearchFilter searchFilter);
        IProduct GetProduct(Guid id);
    }
}