using System;
using System.Collections.Generic;
using System.Data.Entity;
using AzStore.DataAccess.Model;

namespace AzStore.DataAccess
{
    public class AzStoreDbInitializer : DropCreateDatabaseAlways<AzStoreDbContext>
    {
        protected override void Seed(AzStoreDbContext context)
        {
            var electronics = new ProductCategoryEntity() { Id = Guid.NewGuid(), Name = "Electronics" };
            var tools = new ProductCategoryEntity() { Id = Guid.NewGuid(), Name = "Tools" };

            context.ProductCategories.Add(electronics);
            context.ProductCategories.Add(tools);

            IList<ProductEntity> products = new List<ProductEntity>();

            products.Add(new ProductEntity() { Id = Guid.NewGuid(), Sku = "A1RT67C", Name = "Sofa", Description = "South Shore Live - it Cozy 2 - Seat Sofa in Velvet Blue", Price = 349.49m, Rating = 2, ImageUrl = @"~/images/products/sofa.jpg" });
            products.Add(new ProductEntity() { Id = Guid.NewGuid(), Sku = "Z2781RT", Name = "Computer", Description = "HP Slim Desktop PC (AMD A6-9225 / 1TB HDD / 8GB RAM / Windows 10)", Price = 999.99m, Rating = 4, ImageUrl = @"~/images/products/computer.jpg", ProductCategory = electronics });
            products.Add(new ProductEntity() { Id = Guid.NewGuid(), Sku = "BGU75QW", Name = "iPad", Description = "Apple iPad 9.7\" 32GB with Wi - Fi - Space Grey", Price = 849.49m, Rating = 5, ImageUrl = @"~/images/products/ipad.jpg", ProductCategory = electronics });
            products.Add(new ProductEntity() { Id = Guid.NewGuid(), Sku = "FYTP09X", Name = "TV", Description = "Samsung 55\" 4K UHD HDR LED Tizen Smart TV", Price = 399.99m, ImageUrl = @"~/images/products/tv.jpg", ProductCategory = electronics });
            products.Add(new ProductEntity() { Id = Guid.NewGuid(), Sku = "MNBV87T", Name = "Hammer", Description = "", Price = 4.999999999999999m, Rating = 1, ImageUrl = @"~/images/products/hammer.jpg", ProductCategory = tools });

            context.Products.AddRange(products);

            base.Seed(context);
        }
    }
}