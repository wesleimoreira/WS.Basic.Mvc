using NSubstitute;
using WS.MVC.Models;
using WS.MVC.Controllers;
using WS.MVC.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WS.MVCTests.ControllerTests
{
    public class ProductControllerTest
    {
        private readonly ProductModel productCreateTest;
        private readonly ProductModel productUpdateTest;
        private readonly ProductController productController;
        private readonly IProductService productServiceMock;
        private readonly ICategoryService categoryServiceMock;

        public ProductControllerTest()
        {
            productServiceMock = Substitute.For<IProductService>();
            categoryServiceMock = Substitute.For<ICategoryService>();
            productController = new ProductController(productServiceMock, categoryServiceMock);

            productCreateTest = new ProductModel
            {
                ProductName = "Computador de mesa",
                ProductPrice = 2000,
                ProductQuantity = 5,
                IsProductActive = true,
                CategoryId = 2
            };

            productUpdateTest = new ProductModel
            {
                ProductId = 1,
                ProductName = "Computador de mesa",
                ProductPrice = 2000,
                ProductQuantity = 5,
                IsProductActive = true,
                CategoryId = 2
            };
        }

        [Fact]
        public async Task Product_Index_Test()
        {
            ViewResult? viewProductIndex = await productController.Index(0, 25) as ViewResult;

            Assert.Equal("Index", viewProductIndex?.ViewName);

            Assert.True(viewProductIndex?.StatusCode.Equals(200));
        }


        [Fact]
        public async Task Product_Create_Test()
        {
            categoryServiceMock.GetCategories().Returns(new List<CategoryModel>());

            ViewResult? viewProductCreate_Get = await productController.Create() as ViewResult;

            Assert.Equal("Create", viewProductCreate_Get?.ViewName);

            Assert.True(viewProductCreate_Get?.StatusCode.Equals(200));

            productServiceMock.PostProductCreateAsync(productCreateTest).Returns(true);

            RedirectToActionResult? viewProductCreate_Post = await productController.CreateProduct(productCreateTest) as RedirectToActionResult;

            Assert.Equal("Index", viewProductCreate_Post?.ActionName);
        }

        [Fact]
        public async Task Product_Update_Test()
        {
            productServiceMock.GetProductByIdAsync(productUpdateTest.ProductId).Returns(productUpdateTest);

            categoryServiceMock.GetCategories().Returns(new List<CategoryModel>());

            ViewResult? viewProductUpdate_Get = await productController.Update(productUpdateTest.ProductId) as ViewResult;

            Assert.Equal("Update", viewProductUpdate_Get?.ViewName);

            Assert.True(viewProductUpdate_Get?.StatusCode.Equals(200));

            productServiceMock.PutProductUpdateAsync(productUpdateTest).Returns(true);

            RedirectToActionResult? viewProductUpdate_Put = await productController.UpdateProduct(productUpdateTest) as RedirectToActionResult;

            Assert.Equal("Index", viewProductUpdate_Put?.ActionName);
        }


        [Fact]
        public async Task Product_Delete_Test()
        {
            productServiceMock.GetProductByIdAsync(productUpdateTest.ProductId).Returns(productUpdateTest);

            productServiceMock.DeleteProductRemoveAsync(productUpdateTest).Returns(true);

            RedirectToActionResult? viewProductDelete_Put = await productController.DeleteProduct(productUpdateTest.ProductId) as RedirectToActionResult;

            Assert.Equal("Index", viewProductDelete_Put?.ActionName);
        }
    }
}