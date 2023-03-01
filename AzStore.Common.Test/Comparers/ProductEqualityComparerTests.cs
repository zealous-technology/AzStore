using System;
using System.Collections.Generic;
using AzStore.Common.Comparers;
using Moq;
using Xunit;

namespace AzStore.Common.Test.Comparers
{
    public class ProductEqualityComparerTests
    {
        private IEqualityComparer<IProduct> Sut { get; }
        private readonly Mock<IProduct> _product1;
        private readonly Mock<IProduct> _product2;
        private readonly Guid _product1Id = Guid.NewGuid();
        private readonly Guid _product2Id = Guid.NewGuid();

        public ProductEqualityComparerTests()
        {
            _product1 = new Mock<IProduct>();
            _product1.Setup(t => t.Id).Returns(_product1Id);

            _product2 = new Mock<IProduct>();
            _product2.Setup(p => p.Id).Returns(_product2Id);

            Sut = new ProductEqualityComparer();
        }

        [Fact]
        public void Equals_ShouldReturnFalse_WhenIdsDiffer()
        {
            Assert.False(Sut.Equals(_product1.Object, _product2.Object));
        }

        [Fact]
        public void Equals_ShouldReturnTrue_WhenIdsMatch()
        {
            _product2.Setup(p => p.Id).Returns(_product1Id);

            Assert.True(Sut.Equals(_product1.Object, _product2.Object));
        }
    }
}