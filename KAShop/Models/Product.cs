using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace KAShop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
        public string Discription { get; set; }
        [Range(0,3000)]
        public double Price { get; set; }
        public double Discount { get; set; }
        [Range(0,5)]
        public double Rate { get; set; }
        public string? Image { get; set; }
        [Range(0, 300)]
        public int quantity { get; set; }
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category category { get; set; }
        public int CompanyId { get; set; }
        [ValidateNever]
        public Company company { get; set; }
     
    }
}
