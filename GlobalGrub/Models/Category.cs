namespace GlobalGrub.Models
{
    public class Category
    {
        // all pk ields ASP.NET MVC should be called either {Model}Id or Id
        // properties names should always be PascalCase
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}
