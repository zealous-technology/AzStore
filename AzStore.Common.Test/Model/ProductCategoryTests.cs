using System;
using Xunit;
using AzStore.Common.Model;

namespace AzStore.Common.Test.Model
{
    public class ProductCategoryTests
    {
        private IProductCategory Sut { get; }

        private readonly Guid _id = Guid.NewGuid();
        private const string Name = "The name";

        public ProductCategoryTests()
        {
            Sut = new ProductCategory(_id, Name);
       }

        [Fact]
        public void Id_ShouldReturnId()
        {
            Assert.Equal(_id, Sut.Id);
        }

        [Fact]
        public void Name_ShouldReturnName()
        {
            Assert.Equal(Name, Sut.Name);
        }
    }
}