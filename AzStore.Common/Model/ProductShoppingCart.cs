using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AzStore.Common.Model
{
    public class ProductShoppingCart : IShoppingCart<IProduct>
    {
        private readonly object _productLock = new object();

        private readonly IList<IProduct> _products;

        public IReadOnlyCollection<IProduct> Items
        {
            get
            {
                lock (_productLock)
                {
                    return new ReadOnlyCollection<IProduct>(_products.OrderBy(p => p.Name).ToArray());
                }
            }
        }

        public decimal Total
        {
            get
            {
                lock (_productLock)
                {
                    return _products.Sum(p => p.Price);
                }
            }
        }

        public ProductShoppingCart()
        {
            _products = new List<IProduct>();
        }

        public ProductShoppingCart(IEnumerable<IProduct> products)
        {
            _products = new List<IProduct>(products);
        }

        public void Add(IProduct product)
        {
            lock (_productLock)
            {
                if (_products.Any(p => p.Id.Equals(product.Id)))
                    return;

                _products.Add(product);
            }
        }

        public void Remove(IProduct product)
        {
            lock (_productLock)
            {
                var instance = _products.FirstOrDefault(p => p.Id.Equals(product.Id));

                if (instance == null)
                    return;

                _products.Remove(instance);
            }
        }        
    }
}