using System;
using System.ComponentModel.DataAnnotations;
using AzStore.Common;

namespace AzStore.Mvc.Models.Product
{
    public class ProductViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [StringLength(7)]
        [Display(Name="sku")]
        public string Sku { get; set; }

        [Display(Name = "Product")]
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

        public int? Rating { get; set; }

        [Required]
        [StringLength(30)]
        public string ImageUrl { get; set; }

        public ProductCategoryViewModel Category { get; set; }

        public ProductViewModel(IProduct product)
        {
            Id = product.Id;
            Sku = product.Sku;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Rating = product.Rating;
            ImageUrl = product.ImageUrl;
            Category = product.Category == null ? null : new ProductCategoryViewModel(product.Category);
        }
    }
}