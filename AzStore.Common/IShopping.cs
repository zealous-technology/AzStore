using System.Collections.Generic;

namespace AzStore.Common
{
    public interface IShopping<T> where T : IProduct
    {
        IReadOnlyCollection<T> Items { get; }
        decimal Total { get; }
    }
 }