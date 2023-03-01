using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AzStore.DataAccess.Model
{
    [Table("ProductCategory")]
    public class ProductCategoryEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
    }
}