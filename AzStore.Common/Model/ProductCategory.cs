using System;

namespace AzStore.Common.Model
{
    public class ProductCategory : IProductCategory
    {
        public Guid Id { get; }
        public string Name { get; }

        public ProductCategory(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}