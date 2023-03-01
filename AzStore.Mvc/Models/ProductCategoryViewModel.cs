using System;
using System.ComponentModel.DataAnnotations;
using AzStore.Common;

namespace AzStore.Mvc.Models
{
    public class ProductCategoryViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ProductCategoryViewModel(IProductCategory productCategory)
        {
            Id = productCategory.Id;
            Name = productCategory.Name;
        }
    }
}