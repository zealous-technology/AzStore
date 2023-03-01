using Xunit;
using AzStore.Common.Model;

namespace AzStore.Common.Test.Model
{
    public class SearchFilterTests
    {
        private ISearchFilter Sut { get; }

        private const string Text = "The search text";

        public SearchFilterTests()
        {
            Sut = new SearchFilter(Text);
        }

        [Fact]
        public void Text_ShouldReturnText()
        {
            Assert.Equal(Text, Sut.Text);
        }
    }
}