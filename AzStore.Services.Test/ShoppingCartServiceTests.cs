using AzStore.Common;
using AzStore.Test;
using Moq;
using Xunit;

namespace AzStore.Services.Test
{
    public class ShoppingCartServiceTests : FactBase
    {
        private readonly IShoppingCartService _sut;
        private readonly Mock<IShopping<IProduct>> _shopping = new Mock<IShopping<IProduct>>();

        public ShoppingCartServiceTests()
        {
            _sut = CreateSut<ShoppingCartService>();

            MockFor<IValidator<IShopping<IProduct>>>().Setup(v => v.IsValid(It.IsAny<IShopping<IProduct>>())).Returns(true);
        }

        [Fact]
        public void Checkout_ShouldReturnTrue_WhenShoppingIsValid()
        {
            Assert.True(_sut.Checkout(_shopping.Object));
        }

        [Fact]
        public void Checkout_ShouldReturnFalse_WhenShoppingIsNotValid()
        {
            MockFor<IValidator<IShopping<IProduct>>>().Setup(v => v.IsValid(It.IsAny<IShopping<IProduct>>())).Returns(false);

            Assert.False(_sut.Checkout(_shopping.Object));
        }
    }
}