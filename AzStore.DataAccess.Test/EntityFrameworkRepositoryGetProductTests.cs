using System;
using Moq;
using Xunit;
using AzStore.Common;
using AzStore.DataAccess.Model;
using AzStore.Test;
using AzStore.DataAccess.Test.TestInfrastrucuture;
using AzStore.DataAccess.Model.Mappers;

namespace AzStore.DataAccess.Test
{
    public class EntityFrameworkRepositoryGetProductTests : FactBase
    {
        private readonly ProductEntity _productEntity;
        private readonly Guid _productId;
        private readonly Mock<IProduct> _product;

        private IRepository Sut { get; }

        public EntityFrameworkRepositoryGetProductTests()
        {
            _productId = Guid.NewGuid();

            var productEntityDbSet = new TestDbSet<ProductEntity>(new[]
            {
                _productEntity = new ProductEntity { Id = _productId }
            });

            _product = new Mock<IProduct>();

            MockFor<IAzStoreDbContext>().Setup(x => x.Products).Returns(productEntityDbSet);
            MockFor<IEntityMapper<IProduct, ProductEntity>>().Setup(m => m.Map(_productEntity)).Returns(_product.Object);

            Sut = CreateSut<EntityFrameworkRepository>();
        }

        [Fact]
        public void GetProduct_ShouldReturnMappedProduct()
        {
            Assert.Equal(_product.Object, Sut.GetProduct(_productId));
        }

        [Fact]
        public void GetProduct_ShouldReturnNull()
        {
            Assert.Null(Sut.GetProduct(Guid.NewGuid()));
        }
    }
}