namespace WS.MVC.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQuantity { get; set; }
        public decimal ProductPrice { get; set; }
        public Boolean IsProductActive { get; set; }

        public ProductModel(int productId, string productName, int productQuantity, decimal productPrice, Boolean isProductActive)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.ProductPrice = productPrice;
            this.ProductQuantity = productQuantity;
            this.IsProductActive = isProductActive;
        }

        public int CategoryId { get; set; }
        public CategoryModel? GetCategoryModel { get; set; }
    }
}