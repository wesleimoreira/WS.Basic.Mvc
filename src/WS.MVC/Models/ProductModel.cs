namespace WS.MVC.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public string? ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Boolean IsProductActive { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel? GetCategoryModel { get; set; }
    }
}