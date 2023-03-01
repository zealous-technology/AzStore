using System;
using System.Collections.Generic;
using System.Linq;
using AzStore.Common;
using AzStore.Common.Extensions;
using AzStore.DataAccess.Model;
using AzStore.DataAccess.Model.Mappers;

namespace AzStore.DataAccess
{
    public class EntityFrameworkRepository : IRepository
    {
        private readonly IAzStoreDbContext _dbContext;
        private readonly IEntityCollectionMapper<IProduct, ProductEntity> _productsMapper;
        private readonly IEntityCollectionMapper<IProductCategory, ProductCategoryEntity> _productCategoriesMapper;
        private readonly IEntityMapper<IProduct, ProductEntity> _productMapper;
        private readonly IFilter<ProductEntity> _productFilter;

        public EntityFrameworkRepository(IAzStoreDbContext dbContext,
                                         IEntityCollectionMapper<IProduct, ProductEntity> productsMapper,
                                         IEntityCollectionMapper<IProductCategory, ProductCategoryEntity> productCategoriesMapper,
                                         IEntityMapper<IProduct, ProductEntity> productMapper,
                                         IFilter<ProductEntity> productFilter)
        {
            _dbContext = dbContext;
            _productsMapper = productsMapper;
            _productCategoriesMapper = productCategoriesMapper;
            _productMapper = productMapper;
            _productFilter = productFilter;
        }

        public IEnumerable<IProductCategory> GetProductCategories()
        {
            return _productCategoriesMapper.Map(_dbContext.ProductCategories).ToArray();
        }

        public IEnumerable<IProduct> GetProducts(ISearchFilter searchFilter)
        {
            var products = _dbContext.Products.Include("ProductCategory").Filter(_productFilter, searchFilter).OrderBy(p => p.Name);
           
            return _productsMapper.Map(products).ToArray();
        }

        public IProduct GetProduct(Guid id)
        {
            return _productMapper.Map(_dbContext.Products.SingleOrDefault(p => p.Id.Equals(id)));
        }
    }
}