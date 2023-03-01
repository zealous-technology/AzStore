using AzStore.Common;

namespace AzStore.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository _repository;
        private readonly IValidator<IShopping<IProduct>> _validator;

        public ShoppingCartService(IRepository repository, IValidator<IShopping<IProduct>> validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public bool Checkout(IShopping<IProduct> shopping)
        {
            if (!_validator.IsValid(shopping))
                return false;

            // save order
            //_repository.Save(shopping);

            return true;
        }
    }
}