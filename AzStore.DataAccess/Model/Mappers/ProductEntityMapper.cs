using AzStore.Common;
using AzStore.Common.Model;

namespace AzStore.DataAccess.Model.Mappers
{
    public class ProductEntityMapper : IEntityMapper<IProduct, ProductEntity>
    {
        public IProduct Map(ProductEntity product)
        {
            return product == null
                   ? null
                   : new Product(product.Id, product.Sku, product.Name, product.Description, product.Price, product.Rating, product.ImageUrl,
                                 product.ProductCategory == null ? null : new ProductCategory(product.ProductCategory.Id, product.ProductCategory.Name));
        }
    }
}