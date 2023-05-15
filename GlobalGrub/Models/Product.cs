using System.ComponentModel.DataAnnotations;
namespace GlobalGrub.Models
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }

        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Range(0.01, 9999999)]
        [DisplayFormat(DataFormatString = "{0:c}")] // MS currency format
        public decimal Price { get; set; }

        [Required]
        [Range(0, 9999999)]
        public decimal Weight { get; set; }

        public string Photo { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } // reference to parent property

        // child reference
        public List<CartItem> CartItems { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
