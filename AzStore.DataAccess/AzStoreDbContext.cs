using AzStore.DataAccess.Model;
using System.Data.Entity;

namespace AzStore.DataAccess
{
    public class AzStoreDbContext : DbContext, IAzStoreDbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

        public AzStoreDbContext() : base("AzStoreDbContext")
        {
            Database.SetInitializer(new AzStoreDbInitializer());

            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<ProductEntity>()
            .HasOptional(w => w.ProductCategory)
            .WithMany()
            .Map(m => m.MapKey("ProductCategoryId")).WillCascadeOnDelete(false);
        }
    }
}