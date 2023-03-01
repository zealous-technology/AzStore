using System;

namespace AzStore.Common
{
    public interface IProductCategory
    {
        Guid Id { get; }
        string Name { get; }
    }
}