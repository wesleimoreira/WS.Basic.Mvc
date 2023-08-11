using WS.MVC.Models;

namespace WS.MVC.Data.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetCategories();
    }
}