using System.ComponentModel.DataAnnotations;

namespace development_restful_api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
    }

}
