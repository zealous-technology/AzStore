
namespace AzStore.Common
{
    public interface IShoppingCart<T> : IShopping<T> where T : IProduct
    {
        void Add(T item);
        void Remove(T item);
    }
 }