using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace KAShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MinLength(6)]
        public string Name { get; set; }

        [ValidateNever]
        public List<Product> products { get; set; }
    }
}
