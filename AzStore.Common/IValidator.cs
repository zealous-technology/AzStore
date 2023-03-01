
namespace AzStore.Common
{
    public interface IValidator<T>
    {
        bool IsValid(T item);
    }
 }