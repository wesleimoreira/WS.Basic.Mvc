using WS.MVC.Models;

namespace WS.MVC.Data.Interface
{
    public interface IProductService
    {
        Task<ProductModel> GetProductByIdAsync(int productId);
        Task<IEnumerable<ProductModel>> GetProductsAsync(int skip, int take);

        Task<Boolean> PutProductUpdateAsync(ProductModel product);
        Task<Boolean> PostProductCreateAsync(ProductModel product);
        Task<Boolean> DeleteProductRemoveAsync(ProductModel product);
    }
}