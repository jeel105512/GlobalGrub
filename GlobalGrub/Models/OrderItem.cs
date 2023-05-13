using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace GlobalGrub.Models
{
    public class OrderItem
    {
        [Required]
        public int OrderItemId { get; set; }

        [Range(1, 9999999)]
        [Required]
        public int Quantity { get; set; }

        [Range(0.01, 9999999)]
        public double Price { get; set; }

        // fk's
        [Required]
        public int ProductId { get; set; }

        [Required]
        public int OrderId { get; set; }

        // parent references
        public Product Product { get; set; }

        public Order Order { get; set; }
    }
}
