using System;
using Moq;
using Xunit;
using AzStore.Common.Model;

namespace AzStore.Common.Test.Model
{
    public class ProductTests
    {
        private IProduct Sut { get; }

        private readonly Guid _id = Guid.NewGuid();
        private const string Sku = "The product sku";
        private const string Name = "The name";
        private const string Description = "The description";
        private const decimal Price = 12345.67m;
        private readonly int? _rating = 98;
        private const string ImageUrl = "The image";
        private readonly Guid _categoryId = Guid.NewGuid();
        private const string CategoryName = "The category name";

        public ProductTests()
        {
            var category = new Mock<IProductCategory>();
            category.Setup(c => c.Id).Returns(_categoryId);
            category.Setup(c => c.Name).Returns(CategoryName);

            Sut = new Product(_id, Sku, Name, Description, Price, _rating, ImageUrl, category.Object);
       }

        [Fact]
        public void Id_ShouldReturnId()
        {
            Assert.Equal(_id, Sut.Id);
        }

        [Fact]
        public void Sku_ShouldReturnSku()
        {
            Assert.Equal(Sku, Sut.Sku);
        }

        [Fact]
        public void Name_ShouldReturnName()
        {
            Assert.Equal(Name, Sut.Name);
        }

        [Fact]
        public void Description_ShouldReturnDescription()
        {
            Assert.Equal(Description, Sut.Description);
        }

        [Fact]
        public void Price_ShouldReturnPrice()
        {
            Assert.Equal(Price, Sut.Price);
        }

        [Fact]
        public void Rating_ShouldReturnRating()
        {
            Assert.Equal(_rating, Sut.Rating);
        }

        [Fact]
        public void ImageUrl_ShouldReturnImageUrl()
        {
            Assert.Equal(ImageUrl, Sut.ImageUrl);
        }

        [Fact]
        public void CategoryId_ShouldReturnCategoryId()
        {
            Assert.Equal(_categoryId, Sut.Category.Id);
        }

        [Fact]
        public void CategoryName_ShouldReturnCategoryName()
        {
            Assert.Equal(CategoryName, Sut.Category.Name);
        }
    }
}