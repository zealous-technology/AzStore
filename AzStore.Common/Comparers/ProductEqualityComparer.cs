using System.Collections.Generic;

namespace AzStore.Common.Comparers
{
    public class ProductEqualityComparer : IEqualityComparer<IProduct>
    {
        public bool Equals(IProduct x, IProduct y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(IProduct obj)
        {
            return obj.GetHashCode();
        }
    }
}