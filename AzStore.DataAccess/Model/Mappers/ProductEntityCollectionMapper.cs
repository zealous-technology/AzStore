using System.Collections.Generic;
using System.Linq;
using AzStore.Common;

namespace AzStore.DataAccess.Model.Mappers
{
    public class ProductEntityCollectionMapper : IEntityCollectionMapper<IProduct, ProductEntity>
    {
        private readonly IEntityMapper<IProduct, ProductEntity> _productMapper;

        public ProductEntityCollectionMapper(IEntityMapper<IProduct, ProductEntity> productMapper)
        {
            _productMapper = productMapper;
        }

        public IEnumerable<IProduct> Map(IEnumerable<ProductEntity> items)
        {
            return items.Select(p => _productMapper.Map(p));
        }
    }
}