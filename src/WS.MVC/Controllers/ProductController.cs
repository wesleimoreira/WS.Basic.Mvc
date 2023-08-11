using WS.MVC.Models;
using WS.MVC.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WS.MVC.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("[controller]/[action]/{skip:int}/{take:int}")]
        public async Task<IActionResult> Index([FromRoute] int skip, [FromRoute] int take)
        {
            return CustomView<ViewResult>("Index", await _productService.GetProductsAsync(skip, take), 200);
        }

        [HttpGet]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> Create()
        {
            var productCategory = await _categoryService.GetCategories();

            if (productCategory == null) return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 404);

            ViewBag.CategoryName = new SelectList(productCategory, "CategoryId", "CategoryName");

            return CustomView<ViewResult>("Create", null, 200);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> CreateProduct(ProductModel product)
        {
            try
            {
                if (!ModelState.IsValid) CustomView<ViewResult>("Create", null, 400);

                var productResponse = await _productService.PostProductCreateAsync(product);

                if (!productResponse) return CustomView<ViewResult>("Create", null, 400);

                return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 200);
            }
            catch (Exception err)
            {
                TempData["ErrorSQL"] = err.StackTrace;
                return CustomView<ViewResult>("Create", null, 500);
            }
        }

        [HttpGet]
        [Route("[controller]/[action]/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id)
        {
            var productDetail = await _productService.GetProductByIdAsync(id);

            if (productDetail == null) return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 400);

            var productCategory = await _categoryService.GetCategories();

            if (productCategory == null) return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 404);

            ViewBag.CategoryName = new SelectList(productCategory, "CategoryId", "CategoryName");

            return CustomView<ViewResult>("Update", productDetail, 200);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("[controller]/[action]")]
        public async Task<IActionResult> UpdateProduct(ProductModel product)
        {
            try
            {
                if (!ModelState.IsValid) return CustomView<RedirectToActionResult>("Update", new { id = product.ProductId }, 400);

                var productResponse = await _productService.PutProductUpdateAsync(product);

                if (!productResponse) return CustomView<RedirectToActionResult>("Update", new { id = product.ProductId }, 404);

                return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 200);
            }
            catch (Exception err)
            {
                TempData["ErrorSQL"] = err.StackTrace;
                return CustomView<ViewResult>("Update", product, 500);
            }
        }


        [HttpGet]
        [Route("[controller]/[action]/{id:int}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            try
            {
                if (id == 0)
                    return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 400);

                var productdeleted = await _productService.GetProductByIdAsync(id);

                if (productdeleted == null)
                    return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 404);

                var productResponse = await _productService.DeleteProductRemoveAsync(productdeleted);

                if (!productResponse)
                    return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 404);

                return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 200);
            }
            catch (Exception err)
            {
                TempData["ErrorSQL"] = err.StackTrace;
                return CustomView<RedirectToActionResult>("Index", new { skip = 0, take = 25 }, 500);
            }
        }

    }
}