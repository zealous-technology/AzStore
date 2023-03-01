using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzStore.DataAccess.Model
{
    [Table("Product")]
    public class ProductEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(7)]
        public string Sku { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int? Rating { get; set; }

        [Required]
        [StringLength(30)]
        public string ImageUrl { get; set; }
        
        public virtual ProductCategoryEntity ProductCategory { get; set; }       
    }
}