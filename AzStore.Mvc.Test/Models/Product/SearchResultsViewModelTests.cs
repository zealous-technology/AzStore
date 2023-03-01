using Moq;
using Xunit;
using AzStore.Common;
using AzStore.Mvc.Models.Product;
using System.Linq;

namespace AzStore.Mvc.Test.Model.Product
{
    public class ShoppingCartViewModelTests
    {
        private SearchResultsViewModel Sut { get; }
        private readonly Mock<IProduct> _product1, _product2;

        public ShoppingCartViewModelTests()
        {
            _product1 = new Mock<IProduct>();           
            _product1.Setup(p => p.Name).Returns("ProductName1");

            _product2 = new Mock<IProduct>();
            _product2.Setup(p => p.Name).Returns("ProductName2");

            Sut = new SearchResultsViewModel(new[] { _product1.Object, _product2.Object });
        }

        [Fact]
        public void ProductsShouldBeEmpty_WhenGivenEmptyCollection()
        {
            Assert.Empty(new SearchResultsViewModel(Enumerable.Empty<IProduct>()).Products);
        }

        [Fact]
        public void ProductsCount_WhenEmptyCollection()
        {
            Assert.Equal("(0 results)", new SearchResultsViewModel(Enumerable.Empty<IProduct>()).ProductCount);
        }

        [Fact]
        public void ShouldBeOneProduct()
        {
            Assert.Equal(_product1.Object.Name, new SearchResultsViewModel(new[] { _product1.Object }).Products.Single().Name);
        }

        [Fact]
        public void ProductsCount_WhenOneProduct()
        {
            Assert.Equal("(1 result)", new SearchResultsViewModel(new[] { _product1.Object }).ProductCount);
        }

        [Fact]
        public void ShouldBeTwoProduct()
        {
            Assert.Equal(_product1.Object.Name, Sut.Products.First().Name);
            Assert.Equal(_product2.Object.Name, Sut.Products.Last().Name);

        }

        [Fact]
        public void ProductsCount_WhenTwoProduct()
        {
            Assert.Equal("(2 results)", Sut.ProductCount);
        }
    }
}