
namespace AzStore.DataAccess.Model.Mappers
{
    public interface IEntityMapper<T,S> where T : class
                                        where S : class
    {
        T Map(S item);
    }
}