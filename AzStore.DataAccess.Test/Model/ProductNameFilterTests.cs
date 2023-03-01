using System.Linq;
using AzStore.Common;
using AzStore.DataAccess.Model;
using Moq;
using Xunit;

namespace AzStore.DataAccess.Test.Model
{
    public class ProductNameFilterTests
    {
        private IFilter<ProductEntity> Sut { get; }
        private readonly Mock<ISearchFilter> _searchFilter;
        private readonly IQueryable<ProductEntity> _products;
        private const string Text = "TestProduct";

        public ProductNameFilterTests()
        {
            _searchFilter = new Mock<ISearchFilter>();
            _searchFilter.Setup(s => s.Text).Returns(Text);

            Sut = new ProductNameFilter();

            _products = Enumerable.Range(1, 10).Select(i => new ProductEntity() {Name = "TestProduct" + i}).AsQueryable();
        }
        
        [Fact]
        public void Filter_ShouldNotFilter_WhenFilterIsNull()
        {
            Assert.True(_products.SequenceEqual(Sut.Filter(_products, null), new ProductEntityEqualityComparer()));
        }

        [Fact]
        public void Filter_ShouldNotFilter_WhenFilterTextIsNull()
        {
            _searchFilter.Setup(s => s.Text).Returns<string>(null);

            Assert.True(_products.SequenceEqual(Sut.Filter(_products, _searchFilter.Object), new ProductEntityEqualityComparer()));
        }

        [Fact]
        public void Filter_ShouldNotFilter_WhenFilterTextIsEmpty()
        {
            _searchFilter.Setup(s => s.Text).Returns(string.Empty);

            Assert.True(_products.SequenceEqual(Sut.Filter(_products, _searchFilter.Object), new ProductEntityEqualityComparer()));
        }

        [Fact]
        public void Filter_ShouldReturnEmpty_WhenFilteringNull()
        {
            Assert.Empty(Sut.Filter(null, _searchFilter.Object));
        }

        [Fact]
        public void Filter_ShouldReturnEmpty_WhenFilteringEmptyCollection()
        {
            Assert.Empty(Sut.Filter(Enumerable.Empty<ProductEntity>().AsQueryable(), _searchFilter.Object));
        }
        
        [Fact]
        public void Filter_ShouldReturnEmpty_WhenFilterTextDoesNotMatch()
        {
            _searchFilter.Setup(s => s.Text).Returns("I do not match");

            Assert.Empty(Sut.Filter(_products, _searchFilter.Object));
        }
        
        [Fact]
        public void Filter_ShouldReturnAllRecords_WhenSearchTextMatchesAll()
        {
            Assert.True(_products.SequenceEqual(Sut.Filter(_products, _searchFilter.Object), new ProductEntityEqualityComparer()));
        }

        [Fact]
        public void Filter_ShouldReturnTestProduct2_WhenSearchTextMatches()
        {
            _searchFilter.Setup(s => s.Text).Returns("TestProduct2");            

            Assert.Equal("TestProduct2", Sut.Filter(_products, _searchFilter.Object).Single().Name);
        }

        [Fact]
        public void Filter_ShouldReturnTestProduct1andTestProduct10_WhenSearchTextMatches()
        {
            _searchFilter.Setup(s => s.Text).Returns("TestProduct1");

            var result = Sut.Filter(_products, _searchFilter.Object).ToArray();

            Assert.Equal(2, result.Count());
            Assert.Equal("TestProduct1", result.First().Name);
            Assert.Equal("TestProduct10", result.Last().Name);
        }

        [Fact]
        public void Filter_ShouldReturnTestProduct5_WhenSearchTextMatches_MixedCase()
        {
            _searchFilter.Setup(s => s.Text).Returns("pROdUcT5");

            var result = Sut.Filter(_products, _searchFilter.Object).ToArray();

            Assert.Equal("TestProduct5", Sut.Filter(_products, _searchFilter.Object).Single().Name);
        }
    }
}