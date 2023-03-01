using System;
using System.Collections.Generic;
using System.Linq;
using AzStore.Common;
using AzStore.DataAccess.Model;
using AzStore.DataAccess.Model.Mappers;
using Xunit;

namespace AzStore.DataAccess.Test.Model.Mappers
{
    public class ProductCategoryEntityCollectionMapperTests
    {
        private readonly ProductCategoryEntity _productCategory1 = new ProductCategoryEntity() {Id = Guid.NewGuid(), Name = "ProductCategory1"};
        private readonly ProductCategoryEntity _productCategory2 = new ProductCategoryEntity() { Id = Guid.NewGuid(), Name = "ProductCategory2" };
        private readonly IEnumerable<ProductCategoryEntity> _productCategories;
        private IEntityCollectionMapper<IProductCategory, ProductCategoryEntity> Sut { get; }

        public ProductCategoryEntityCollectionMapperTests()
        {
            _productCategories = new[] { _productCategory1, _productCategory2 };

            Sut = new ProductCategoryEntityCollectionMapper();
        }

        [Fact]
        public void Map_ShouldReturnEmpty_WhenProductCategoryEntityCollectionIsEmpty()
        {
            Assert.Empty(Sut.Map(Enumerable.Empty<ProductCategoryEntity>()));
        }

        [Fact]
        public void Map_ShouldReturnTwoProductCategories()
        {
            Assert.Equal(2, Sut.Map(_productCategories).Count());
        }

        [Fact]
        public void Map_ShouldMapProductCategory1()
        {
            var result = Sut.Map(_productCategories).First();
            Assert.Equal(_productCategory1.Id, result.Id);
            Assert.Equal(_productCategory1.Name, result.Name);
        }

        [Fact]
        public void Map_ShouldMapProductCategory2()
        {
            var result = Sut.Map(_productCategories).Last();
            Assert.Equal(_productCategory2.Id, result.Id);
            Assert.Equal(_productCategory2.Name, result.Name);
        }
    }
}