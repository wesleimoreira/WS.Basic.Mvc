namespace WS.MVC.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public IEnumerable<ProductModel>? GetProductModels { get; set; }

    }
}