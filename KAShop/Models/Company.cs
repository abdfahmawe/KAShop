using System.ComponentModel.DataAnnotations;

namespace KAShop.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public List<Product> products { get; set; }

    }
}
