using System.ComponentModel.DataAnnotations;

namespace GlobalGrub.Models
{
    public class Category
    {
        // all pk ields ASP.NET MVC should be called either {Model}Id or Id
        // properties names should always be PascalCase
        [Display(Name = "Category Id")] // this sets an alias for all labels globally
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a name for the category.")]
        [MaxLength(100)]
        public string Name { get; set; }

        /*[Key]
        [Required]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The Name field is required.")]
        [StringLength(100, ErrorMessage = "The Name field must be a string with a maximum length of 100 characters.")]
        public string Name { get; set; }*/





        // child reference
        public List<Product> Products { get; set; }
    }
}
