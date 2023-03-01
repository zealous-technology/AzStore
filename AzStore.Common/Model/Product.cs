using System;

namespace AzStore.Common.Model
{
    public class Product : IProduct
    {
        public Guid Id { get; }
        public string Sku { get; }
        public string Name { get; }
        public string Description { get; }
        public decimal Price { get; }
        public int? Rating { get; set; }
        public string ImageUrl { get; }
        public IProductCategory Category { get; }

        public Product(Guid id, string sku, string name, string description, decimal price, int? rating, string imageUrl, IProductCategory category)
        {
            Id = id;
            Sku = sku;
            Name = name;
            Description = description;
            Price = price;
            Rating = rating;
            ImageUrl = imageUrl;
            Category = category;
        }
    }
}