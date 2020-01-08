using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProductsWebsite.Controllers;
using ProductsWebsite.Models;
using ProductsWebsite.Repositories;
using ProductsWebsite.Tests.FakeRepositories;

namespace ProductsWebsite.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void IndexModelShouldContainAllProducts()
        {
            IProductRepository productRepository = new FakeProductRepository();
            ProductController productController = new ProductController(productRepository);

            ViewResult viewResult = productController.Index() as ViewResult;
            List<Product> products = viewResult.Model as List<Product>;

            Assert.AreEqual(products.Count, 3);
        }

        [TestMethod]
        public void GetProductModelShouldContainTheRightProduct()
        {
            IProductRepository productRepository = new FakeProductRepository();
            ProductController productController = new ProductController(productRepository);

            ViewResult viewResult = productController.GetProduct(2) as ViewResult;
            Product product = viewResult.Model as Product;

            Assert.AreEqual(product.Id, 2);

        }
    }
}
