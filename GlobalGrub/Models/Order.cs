using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace GlobalGrub.Models
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please make sure to fill the First Name")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please make sure to fill the Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(0, 9999999)]
        public double Price { get; set; }

        public DateTime OrderDate{ get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please make sure to fill the Address")]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please make sure to fill the City")]
        public string City { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please make sure to fill the Province")]
        public string Province { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please make sure to fill the Postal Code")]
        public string PostalCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please make sure to fill the Phone Number")]
        public string Phone { get; set; }

        public string PaymentCode { get; set; }

        [Required]
        public string UserId { get; set; }

        // child references
        public List<OrderItem> OrderItems { get; set; }
    }
}
