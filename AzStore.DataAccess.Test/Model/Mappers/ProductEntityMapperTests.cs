using System;
using AzStore.Common;
using AzStore.DataAccess.Model;
using AzStore.DataAccess.Model.Mappers;
using Xunit;

namespace AzStore.DataAccess.Test.Model.Mappers
{
    public class ProductEntityMapperTests
    {
        private readonly ProductEntity _product = new ProductEntity()
            {
                Id = Guid.NewGuid(),
                Sku = "The sku",
                Name = "The product name",
                Description = "The description",
                Price = 99,
                Rating = 5,
                ImageUrl = "The image url"

            };

        private readonly ProductCategoryEntity _productCategory =new ProductCategoryEntity() {Id = Guid.NewGuid(), Name = "The product category name"};

        private IEntityMapper<IProduct, ProductEntity> Sut { get; }

        public ProductEntityMapperTests()
        {
            Sut = new ProductEntityMapper();
        }

        [Fact]
        public void Map_ShouldReturnNull_WhenProductEntityIsNull()
        {
            Assert.Null(Sut.Map(null));
        }        

        [Fact]
        public void Map_ShouldMapId()
        {
            Assert.Equal(_product.Id, Sut.Map(_product).Id);
        }

        [Fact]
        public void Map_ShouldMapSku()
        {
            Assert.Equal(_product.Sku, Sut.Map(_product).Sku);
        }

        [Fact]
        public void Map_ShouldMapName()
        {
            Assert.Equal(_product.Name, Sut.Map(_product).Name);
        }

        [Fact]
        public void Map_ShouldMapDescription()
        {
            Assert.Equal(_product.Description, Sut.Map(_product).Description);
        }

        [Fact]
        public void Map_ShouldMapPrice()
        {
            Assert.Equal(_product.Price, Sut.Map(_product).Price);
        }

        [Fact]
        public void Map_ShouldMapRating()
        {
            Assert.Equal(_product.Rating, Sut.Map(_product).Rating);
        }

        [Fact]
        public void Map_ShouldMapImageUrl()
        {
            Assert.Equal(_product.ImageUrl, Sut.Map(_product).ImageUrl);
        }

        [Fact]
        public void Map_ShouldNotMapProductCategory_WhenItIsNull()
        {
            Assert.Null(Sut.Map(_product).Category);
        }

        [Fact]
        public void Map_ShouldMapProductCategoryId()
        {
            _product.ProductCategory = _productCategory;

            Assert.Equal(_product.ProductCategory.Id, Sut.Map(_product).Category.Id);
        }

        [Fact]
        public void Map_ShouldMapProductCategoryName()
        {
            _product.ProductCategory = _productCategory;

            Assert.Equal(_product.ProductCategory.Name, Sut.Map(_product).Category.Name);
        }
    }
}