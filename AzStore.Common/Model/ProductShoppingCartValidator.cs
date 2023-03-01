using System.Linq;

namespace AzStore.Common.Model
{
    public class ProductShoppingCartValidator : IValidator<IShopping<IProduct>>
    {
        public bool IsValid(IShopping<IProduct> shopping) => shopping?.Items?.Any() ?? false;        
    }
}