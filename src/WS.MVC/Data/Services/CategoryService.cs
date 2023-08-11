using WS.MVC.Models;
using WS.MVC.Data.Context;
using WS.MVC.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace WS.MVC.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly MyContext _context;
        public CategoryService(MyContext context) => _context = context;
        public async Task<IEnumerable<CategoryModel>> GetCategories() => await _context.Categories.AsNoTracking().ToListAsync();
    }
}