using System;
using Moq;
using Xunit;
using System.Linq;
using AzStore.Common.Model;

namespace AzStore.Common.Test.Model
{
    public class ProductShoppingCartTests
    {
        private IShoppingCart<IProduct> Sut { get; set; }
        private readonly Mock<IProduct> _tv;
        private readonly Mock<IProduct> _iPad;
        private const decimal TvPrice = 999m;
        private const decimal IPadPrice = 849.99m;

        public ProductShoppingCartTests()
        {
            _tv = new Mock<IProduct>();
            _tv.Setup(p => p.Id).Returns(Guid.NewGuid());
            _tv.Setup(p => p.Price).Returns(TvPrice);

            _iPad = new Mock<IProduct>();
            _iPad.Setup(p => p.Id).Returns(Guid.NewGuid());
            _iPad.Setup(p => p.Price).Returns(IPadPrice);

            Sut = new ProductShoppingCart();
       }

        [Fact]
        public void ShouldBeEmpty_WhenCreatedWithoutItems()
        {
            Sut = new ProductShoppingCart();

            Assert.Empty(Sut.Items);
        }

        [Fact]
        public void ShouldBeEmpty_WhenCreatedWithEmptyCollection()
        {
            Sut = new ProductShoppingCart(Enumerable.Empty<IProduct>());

            Assert.Empty(Sut.Items);
        }

        [Fact]
        public void ShouldContainTwoProducts_WhenCreatedWithCollection()
        {
            Sut = new ProductShoppingCart(new[] { _tv.Object, _iPad.Object });

            Assert.Equal(2, Sut.Items.Count);
            Assert.Single(Sut.Items, _tv.Object);
            Assert.Single(Sut.Items, _iPad.Object);
        }

        [Fact]
        public void Add_ShouldAddProduct_WhenProductNotInCart()
        {
            Sut = new ProductShoppingCart();

            Sut.Add(_tv.Object);

            Assert.Equal(1, Sut.Items.Count);
            Assert.Single(Sut.Items, _tv.Object);
        }

        [Fact]
        public void Add_ShouldNotAddProduct_WhenAlreadyInCart()
        {
            Sut = new ProductShoppingCart(new[] { _tv.Object });

            Sut.Add(_tv.Object);

            Assert.Equal(1, Sut.Items.Count);
            Assert.Single(Sut.Items, _tv.Object);
        }

        [Fact]
        public void Add_ShouldAddProduct_WhenDifferentProduct()
        {
            Sut = new ProductShoppingCart(new[] { _tv.Object });

            Sut.Add(_iPad.Object);

            Assert.Equal(2, Sut.Items.Count);
            Assert.Single(Sut.Items, _tv.Object);
            Assert.Single(Sut.Items, _iPad.Object);
        }
      
        [Fact]
        public void Remove_ShouldNotRemoveProduct_WhenCartIsEmpty()
        {
            Sut = new ProductShoppingCart();

            Sut.Remove(_tv.Object);

            Assert.Empty(Sut.Items);
        }

        [Fact]
        public void Remove_ShouldNotRemoveProduct_WhenProductNotInCart()
        {
            Sut = new ProductShoppingCart(new[] { _tv.Object });
            
            Sut.Remove(_iPad.Object);

            Assert.Equal(1, Sut.Items.Count);
            Assert.Single(Sut.Items, _tv.Object);
        }

        [Fact]
        public void Remove_ShouldRemoveProduct_WhenItIsInCart()
        {
            Sut = new ProductShoppingCart(new[] { _tv.Object });

            Sut.Remove(_tv.Object);

            Assert.DoesNotContain(_tv.Object, Sut.Items);
            Assert.Empty(Sut.Items);
        }

        [Fact]
        public void Total_ShouldBe0_WhenCartIsEmpty()
        {            
            Assert.Equal(0, new ProductShoppingCart().Total);
        }

        [Fact]
        public void Total_ShouldBePriceOfTv_WhenCartContainsTv()
        {
            Sut = new ProductShoppingCart(new[] { _tv.Object });

            Assert.Equal(TvPrice, Sut.Total);
        }

        [Fact]
        public void Total_ShouldBePriceOfiPad_WhenCartContainsiPad()
        {
            Sut = new ProductShoppingCart(new[] { _iPad.Object });

            Assert.Equal(IPadPrice, Sut.Total);
        }

        [Fact]
        public void Total_ShouldBeSumOfTvAndiPad_WhenCartContainsTvAndiPad()
        {
            Sut = new ProductShoppingCart(new[] { _tv.Object , _iPad.Object });

            Assert.Equal(TvPrice + IPadPrice, Sut.Total);
        }
    }
}