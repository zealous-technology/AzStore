using System;

namespace AzStore.Common
{
    public interface IProduct : IPrice
    {
        Guid Id { get; }
        string Sku { get; }
        string Name { get; }
        string Description { get; }
        int? Rating { get; set; }
        string ImageUrl { get; }
        IProductCategory Category { get; }
    }
}