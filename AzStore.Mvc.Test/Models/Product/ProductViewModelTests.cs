using System;
using Moq;
using Xunit;
using AzStore.Common;
using AzStore.Mvc.Models.Product;

namespace AzStore.Mvc.Test.Model.Product
{
    public class ProductViewModelTests
    {
        private readonly Mock<IProduct> _product;
        private readonly Mock<IProductCategory> _productCategory;

        public ProductViewModelTests()
        {
            _product = new Mock<IProduct>();
            _product.Setup(p => p.Id).Returns(Guid.NewGuid());
            _product.Setup(p => p.Sku).Returns("The Sku");
            _product.Setup(p => p.Name).Returns("The product name");
            _product.Setup(p => p.Name).Returns("The description");
            _product.Setup(p => p.Price).Returns(99);
            _product.Setup(p => p.Rating).Returns(5);
            _product.Setup(p => p.ImageUrl).Returns("The image url");

            _productCategory = new Mock<IProductCategory>();
            _productCategory.Setup(c => c.Id).Returns(Guid.NewGuid());
            _productCategory.Setup(c => c.Name).Returns("The category name");
        }

        [Fact]
        public void ShouldMapId()
        {
            Assert.Equal(_product.Object.Id, new ProductViewModel(_product.Object).Id);
        }

        [Fact]
        public void ShouldMapSku()
        {
            Assert.Equal(_product.Object.Sku, new ProductViewModel(_product.Object).Sku);
        }

        [Fact]
        public void ShouldMapName()
        {
            Assert.Equal(_product.Object.Name, new ProductViewModel(_product.Object).Name);
        }

        [Fact]
        public void ShouldMapDescription()
        {
            Assert.Equal(_product.Object.Description, new ProductViewModel(_product.Object).Description);
        }

        [Fact]
        public void ShouldMapPrice()
        {
            Assert.Equal(_product.Object.Price, new ProductViewModel(_product.Object).Price);
        }

        [Fact]
        public void ShouldMapRating()
        {
            Assert.Equal(_product.Object.Rating, new ProductViewModel(_product.Object).Rating);
        }

        [Fact]
        public void ShouldMapImageUrl()
        {
            Assert.Equal(_product.Object.ImageUrl, new ProductViewModel(_product.Object).ImageUrl);
        }

        [Fact]
        public void ShouldNotMapProductCategory_WhenItIsNull()
        {
            Assert.Null(new ProductViewModel(_product.Object).Category);
        }

        [Fact]
        public void ShouldMapProductCategoryId()
        {
            _product.Setup(p => p.Category).Returns(_productCategory.Object);

            Assert.Equal(_product.Object.Category.Id, new ProductViewModel(_product.Object).Category.Id);
        }

        [Fact]
        public void ShouldMapProductCategoryName()
        {
            _product.Setup(p => p.Category).Returns(_productCategory.Object);

            Assert.Equal(_product.Object.Category.Name, new ProductViewModel(_product.Object).Category.Name);
        }
    }
}