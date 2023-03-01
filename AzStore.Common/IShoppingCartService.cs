
namespace AzStore.Common
{
    public interface IShoppingCartService
    {
        bool Checkout(IShopping<IProduct> shopping);
    }
}