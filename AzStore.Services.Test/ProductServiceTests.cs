using System;
using System.Collections.Generic;
using System.Linq;
using AzStore.Common;
using AzStore.Test;
using Moq;
using Xunit;

namespace AzStore.Services.Test
{
    public class ProductServiceTests : FactBase
    {
        private readonly IProductService _sut;
        private readonly IEnumerable<IProductCategory> _productCategories;
        private readonly IEnumerable<IProduct> _products;
        private readonly Mock<ISearchFilter> _searchFilter = new Mock<ISearchFilter>();
        private readonly Mock<IProduct> _product = new Mock<IProduct>();

        public ProductServiceTests()
        {
            _productCategories = Enumerable.Range(1, 10).Select(i =>
            {
                var productCategory = new Mock<IProductCategory>();
                productCategory.Setup(p => p.Id).Returns(Guid.NewGuid());
                return productCategory.Object;
            }).ToArray();

            _products = Enumerable.Range(1, 10).Select(i =>
            {
                var product = new Mock<IProduct>();
                product.Setup(p => p.Id).Returns(Guid.NewGuid());
                return product.Object;
            }).ToArray();

            _sut = CreateSut<ProductService>();
            
            MockFor<IRepository>().Setup(r => r.GetProductCategories()).Returns(_productCategories);
            MockFor<IRepository>().Setup(r => r.GetProducts(It.IsAny<ISearchFilter>())).Returns(_products);
            MockFor<IRepository>().Setup(r => r.GetProduct(It.IsAny<Guid>())).Returns(_product.Object);
        }

        [Fact]
        public void GetProductCategories_ShouldReturnEmpty_WhenRepositoryReturnsEmptyCollection()
        {
            MockFor<IRepository>().Setup(r => r.GetProductCategories()).Returns(Enumerable.Empty<IProductCategory>());

            Assert.Empty(_sut.GetProductCategories());
        }

        [Fact]
        public void GetProductCategories_ShouldReturnProductCategories_WhenRepositoryReturnsProductCategories()
        {
            Assert.True(_productCategories.SequenceEqual(_sut.GetProductCategories()));
        }

        [Fact]
        public void GetProducts_ShouldReturnEmpty_WhenRepositoryReturnsEmptyCollection()
        {
            MockFor<IRepository>().Setup(r => r.GetProducts(It.IsAny<ISearchFilter>())).Returns(Enumerable.Empty<IProduct>());

            Assert.Empty(_sut.GetProducts(_searchFilter.Object));
        }

        [Fact]
        public void GetProducts_ShouldReturnProducts_WhenRepositoryReturnsProducts()
        {            
            Assert.True(_products.SequenceEqual(_sut.GetProducts(_searchFilter.Object)));
        }

        [Fact]
        public void GetProduct_ShouldReturnProduct_WhenRepositoryReturnsProduct()
        {
            Assert.Equal(_product.Object, _sut.GetProduct(Guid.NewGuid()));
        }

        [Fact]
        public void GetProduct_ShouldReturnNull_WhenRepositoryReturnsNull()
        {
            MockFor<IRepository>().Setup(r => r.GetProduct(It.IsAny<Guid>())).Returns<IProduct>(null);
            Assert.Null(_sut.GetProduct(Guid.NewGuid()));
        }
    }
}