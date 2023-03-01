using System.Linq;

namespace AzStore.Common
{
    public interface IFilter<T>
    {
        IQueryable<T> Filter(IQueryable<T> collection, ISearchFilter searchFilter);
    }
}