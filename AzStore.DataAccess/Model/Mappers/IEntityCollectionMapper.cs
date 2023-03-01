using System.Collections.Generic;

namespace AzStore.DataAccess.Model.Mappers
{
    public interface IEntityCollectionMapper<T,S> where T : class 
                                                  where S : class
    {
        IEnumerable<T> Map(IEnumerable<S> items);
    }
}