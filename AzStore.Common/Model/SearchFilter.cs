
namespace AzStore.Common.Model
{
    public class SearchFilter : ISearchFilter
    {
        public string Text { get; }

        public SearchFilter(string text)
        {
            Text = text;
        }
    }
}