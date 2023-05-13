using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;

namespace GlobalGrub.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        [Range(1, 9999999)]
        [Required]
        public int Quantity { get; set; }

        [Range(0.01, 9999999)]
        [Required]
        public double Price { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public Product Product { get; set; } // represents the parent object (1 product to many cartitems)
    }
}
