using AzStore.DataAccess.Model;
using System;
using System.Data.Entity;

namespace AzStore.DataAccess
{
    public interface IAzStoreDbContext : IDisposable
    {
        DbSet<ProductEntity> Products { get; set; }

        DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    }
}