using Moq;
using Xunit;
using AzStore.Common;
using System.Linq;
using AzStore.Mvc.Models.ShoppingCart;
using System.Collections.ObjectModel;

namespace AzStore.Mvc.Test.Model.ShoppingCart
{
    public class ShoppingCartViewModelTests
    {
        private ShoppingCartViewModel Sut { get; }
        private readonly Mock<IShoppingCart<IProduct>> _shoppingCart;
        private readonly Mock<IProduct> _product1, _product2;
        private readonly decimal _total = 9876.23m;

        public ShoppingCartViewModelTests()
        {
            _product1 = new Mock<IProduct>();           
            _product1.Setup(p => p.Name).Returns("ProductName1");

            _product2 = new Mock<IProduct>();
            _product2.Setup(p => p.Name).Returns("ProductName2");

            _shoppingCart = new Mock<IShoppingCart<IProduct>>();
            _shoppingCart.Setup(s => s.Items).Returns(new[] { _product1.Object, _product2.Object });
            _shoppingCart.Setup(s => s.Total).Returns(_total);

            Sut = new ShoppingCartViewModel(_shoppingCart.Object);
        }

        [Fact]
        public void ProductsShouldBeEmpty_WhenShoppingCartIsEmpty()
        {
            _shoppingCart.Setup(s => s.Items).Returns(new ReadOnlyCollection<IProduct>(new IProduct[0]));

            Assert.Empty(new ShoppingCartViewModel(_shoppingCart.Object).Products);
        }
        
        [Fact]
        public void ProductsCountShouldBe0_WhenShoppingCartIsEmpty()
        {
            _shoppingCart.Setup(s => s.Items).Returns(new ReadOnlyCollection<IProduct>(new IProduct[0]));

            Assert.Equal("(0 items)", new ShoppingCartViewModel(_shoppingCart.Object).ProductCount);
        }

        [Fact]
        public void CheckoutShouldBeDisabled__WhenShoppingCartIsEmpty()
        {
            _shoppingCart.Setup(s => s.Items).Returns(new ReadOnlyCollection<IProduct>(new IProduct[0]));

            Assert.True(new ShoppingCartViewModel(_shoppingCart.Object).DisableCheckout);
        }

        [Fact]
        public void ShouldBeOneProduct()
        {
            _shoppingCart.Setup(s => s.Items).Returns(new ReadOnlyCollection<IProduct>(new[] { _product1.Object }));

            Assert.Equal(_product1.Object.Name, new ShoppingCartViewModel(_shoppingCart.Object).Products.Single().Name);
        }

        [Fact]
        public void ProductsCount_WhenOneProduct()
        {
            _shoppingCart.Setup(s => s.Items).Returns(new ReadOnlyCollection<IProduct>(new[] { _product1.Object }));

            Assert.Equal("(1 item)", new ShoppingCartViewModel(_shoppingCart.Object).ProductCount);
        }

        [Fact]
        public void CheckoutShouldEnabled__WhenShoppingCartIsNotEmpty()
        {
            _shoppingCart.Setup(s => s.Items).Returns(new ReadOnlyCollection<IProduct>(new[] { _product1.Object }));

            Assert.False(new ShoppingCartViewModel(_shoppingCart.Object).DisableCheckout);
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
            Assert.Equal("(2 items)", Sut.ProductCount);
        }

        [Fact]
        public void Total_ShouldBeShoppingCartTotal()
        {
            Assert.Equal(_shoppingCart.Object.Total, Sut.Total);
        }
    }
}