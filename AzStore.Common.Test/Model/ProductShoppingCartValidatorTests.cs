using System.Collections.Generic;
using System.Collections.ObjectModel;
using Moq;
using Xunit;
using AzStore.Common.Model;
using AzStore.Test;

namespace AzStore.Common.Test.Model
{
    public class ProductShoppingCartValidatorTests : FactBase
    {
        private IValidator<IShopping<IProduct>> Sut { get; }
        private readonly Mock<IShopping<IProduct>> _shopping;

        public ProductShoppingCartValidatorTests()
        {
            _shopping = new Mock<IShopping<IProduct>>();
            _shopping.Setup(s => s.Items).Returns(new[] {new Mock<IProduct>().Object});

            Sut = CreateSut<ProductShoppingCartValidator>();
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenShoppingIsNull()
        {
            Assert.False(Sut.IsValid(null));
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenShoppingItemsIsNull()
        {
            _shopping.Setup(s => s.Items).Returns<IReadOnlyCollection<IProduct>>(null);

            Assert.False(Sut.IsValid(_shopping.Object));
        }

        [Fact]
        public void IsValid_ShouldBeFalse_WhenShoppingIsEmpty()
        {
            _shopping.Setup(s => s.Items).Returns(new ReadOnlyCollection<IProduct>(new IProduct[0]));

            Assert.False(Sut.IsValid(_shopping.Object));
        }

        [Fact]
        public void IsValid_ShouldBeTrue_WhenShoppingIsNotEmpty()
        {
            Assert.True(Sut.IsValid(_shopping.Object));
        }
    }
}