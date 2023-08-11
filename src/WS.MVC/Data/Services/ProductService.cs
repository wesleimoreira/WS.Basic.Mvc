using WS.MVC.Models;
using WS.MVC.Data.Context;
using WS.MVC.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace WS.MVC.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly MyContext _context;
        public ProductService(MyContext context) => _context = context;
        public async Task<ProductModel> GetProductByIdAsync(int productId)
        {
            return await _context
            .Products
            .AsNoTracking()
            .Where(x => x.ProductId == productId)
            .Include(x => x.GetCategoryModel)
            .FirstAsync();
        }

        public async Task<IEnumerable<ProductModel>> GetProductsAsync(int skip, int take)
        {
            return await _context
            .Products
            .AsNoTracking()
            .Where(x => x.IsProductActive)
            .Skip(skip)
            .Take(take)
            .Include(x => x.GetCategoryModel)
            .ToListAsync();
        }

        public async Task<bool> PostProductCreateAsync(ProductModel product)
        {
            var productResponse = await _context.Products.AddAsync(product);

            if (productResponse.State != EntityState.Added) return false;

            if (await _context.SaveChangesAsync() == 0) return false;

            return true;
        }

        public async Task<bool> PutProductUpdateAsync(ProductModel product)
        {
            var productResponse = _context.Products.Update(product);

            if (productResponse.State != EntityState.Modified) return false;

            if (await _context.SaveChangesAsync() == 0) return false;

            return true;
        }

        public async Task<bool> DeleteProductRemoveAsync(ProductModel product)
        {
            var productResponse = _context.Products.Remove(product);

            if (productResponse.State != EntityState.Deleted) return false;

            if (await _context.SaveChangesAsync() == 0) return false;

            return true;
        }
    }
}