using System.ComponentModel.DataAnnotations;

namespace GlobalGrub.Models
{
    public class Category
    {
        // all pk ields ASP.NET MVC should be called either {Model}Id or Id
        // properties names should always be PascalCase
        
        [Range(1, 9999999)]
        [Display(Name = "Category Id")] // this sets an alias for all labels globally
        public int CategoryId { get; set; }

        [Required(AllowEmptyStrings =  false, ErrorMessage = "And no empty string ther")]
        public string Name { get; set; }
    }
}
