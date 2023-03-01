using Moq;
using Xunit;
using System.Linq;
using AzStore.Common;
using AzStore.DataAccess.Model;
using AzStore.Test;
using AzStore.DataAccess.Test.TestInfrastrucuture;
using AzStore.DataAccess.Model.Mappers;

namespace AzStore.DataAccess.Test
{
    public class EntityFrameworkRepositoryGetProductsTests : FactBase
    {
        private readonly ProductEntity _productEntityZZZ, _productEntityTTT, _productEntityBBB;
        private readonly Mock<IProduct> _productZZZ, _productTTT, _productBBB;
        private readonly Mock<ISearchFilter> _searchFilter;
        private const string ProductNameZZZ = "ZZZ";
        private const string ProductNameTTT = "TTT";
        private const string ProductNameBBB = "BBB";

        private IRepository Sut { get; }

        public EntityFrameworkRepositoryGetProductsTests()
        {
            var productEntities = new[]
            {
                _productEntityZZZ = new ProductEntity { Name = ProductNameZZZ },
                _productEntityTTT = new ProductEntity { Name = ProductNameTTT },
                _productEntityBBB = new ProductEntity { Name = ProductNameBBB }
            };

            var productEntityDbSet = new TestDbSet<ProductEntity>(productEntities);

            _productZZZ = new Mock<IProduct>();
            _productZZZ.Setup(p => p.Name).Returns(ProductNameZZZ);

            _productTTT = new Mock<IProduct>();
            _productTTT.Setup(p => p.Name).Returns(ProductNameTTT);

            _productBBB = new Mock<IProduct>();
            _productBBB.Setup(p => p.Name).Returns(ProductNameBBB);

            _searchFilter = new Mock<ISearchFilter>();

            MockFor<IAzStoreDbContext>().Setup(x => x.Products).Returns(productEntityDbSet);

            MockFor<IFilter<ProductEntity>>().Setup(f => f.Filter(productEntityDbSet, _searchFilter.Object)).Returns(productEntityDbSet);

            var orderedProductEntities = new[] { _productEntityBBB, _productEntityTTT, _productEntityZZZ };
 
            MockFor<IEntityCollectionMapper<IProduct, ProductEntity>>().Setup(m => m.Map(orderedProductEntities)).Returns(new[] { _productBBB.Object, _productTTT.Object, _productZZZ.Object });

            Sut = CreateSut<EntityFrameworkRepository>();
        }

        [Fact]
        public void GetProducts_ShouldReturnThreeProducts()
        {
            Assert.Equal(3, Sut.GetProducts(_searchFilter.Object).Count());           
        }

        [Fact]
        public void GetProducts_ShouldReturnProductsOrderedByName()
        {
            var result = Sut.GetProducts(_searchFilter.Object).ToArray();

            Assert.Equal(_productBBB.Object, result[0]);
            Assert.Equal(_productTTT.Object, result[1]);
            Assert.Equal(_productZZZ.Object, result[2]);
        }
    }
}