using System;
using System.Collections.Generic;
using System.Linq;
using AzStore.Common;
using AzStore.DataAccess.Model;
using AzStore.DataAccess.Model.Mappers;
using AzStore.Test;
using Moq;
using Xunit;

namespace AzStore.DataAccess.Test.Model.Mappers
{
    public class ProductEntityCollectionMapperTests : FactBase
    {
        private readonly ProductEntity _product1 = new ProductEntity() {Id = Guid.NewGuid(), Name = "Product1"};
        private readonly ProductEntity _product2 = new ProductEntity() { Id = Guid.NewGuid(), Name = "Product2" };

        private readonly IEnumerable<ProductEntity> _products;
        private IEntityCollectionMapper<IProduct, ProductEntity> Sut { get; }

        public ProductEntityCollectionMapperTests()
        {
            _products = new[] { _product1, _product2 };

            var mappedProduct1 = new Mock<IProduct>();
            mappedProduct1.Setup(p => p.Name).Returns("Product1");

            var mappedProduct2 = new Mock<IProduct>();
            mappedProduct2.Setup(p => p.Name).Returns("Product2");

            MockFor<IEntityMapper<IProduct, ProductEntity>>().Setup(m => m.Map(_product1)).Returns(mappedProduct1.Object);
            MockFor<IEntityMapper<IProduct, ProductEntity>>().Setup(m => m.Map(_product2)).Returns(mappedProduct2.Object);

            Sut = CreateSut<ProductEntityCollectionMapper>();
        }

        [Fact]
        public void Map_ShouldReturnEmpty_WhenProductEntityCollectionIsEmpty()
        {
            Assert.Empty(Sut.Map(Enumerable.Empty<ProductEntity>()));
        }
        
        [Fact]
        public void Map_ShouldReturnTwoProducts()
        {
            Assert.Equal(2, Sut.Map(_products).Count());
        }

        [Fact]
        public void Map_ShouldMapProduct1()
        {
            Assert.NotNull(Sut.Map(_products).FirstOrDefault(p => p.Name.Equals(_product1.Name)));
        }

        [Fact]
        public void Map_ShouldMapProduct2()
        {
            Assert.NotNull(Sut.Map(_products).FirstOrDefault(p => p.Name.Equals(_product2.Name)));
        }
    }
}