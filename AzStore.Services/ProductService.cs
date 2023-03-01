using System;
using System.Collections.Generic;
using AzStore.Common;

namespace AzStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IProductCategory> GetProductCategories()
        {
            return _repository.GetProductCategories();
        }     

        public IEnumerable<IProduct> GetProducts(ISearchFilter searchFilter)
        {
            return _repository.GetProducts(searchFilter);
        }

        public IProduct GetProduct(Guid id)
        {
            return _repository.GetProduct(id);
        }
    }
}