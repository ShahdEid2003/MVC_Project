using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }        
        public string Description { get; set; }

        [Range(0, 100000)]
        public decimal Price { get; set; }

        [Range(0, 5)]
        public double Rate { get; set; }

        [Range(0, 500)]
        public int Quantity { get; set; }

        public double Discount { get; set; }
        public string? Image { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }

    }
}
