using System.Collections.Generic;
using AzStore.DataAccess.Model;

namespace AzStore.DataAccess.Test.Model
{
    public class ProductEntityEqualityComparer : IEqualityComparer<ProductEntity>
    {
        public bool Equals(ProductEntity x, ProductEntity y)
        {
            return x.Name.Equals(y.Name);
        }

        public int GetHashCode(ProductEntity obj)
        {
            return obj.GetHashCode();
        }
    }
}