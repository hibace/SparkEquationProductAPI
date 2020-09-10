using Microsoft.VisualStudio.TestTools.UnitTesting;
using SparkEquation.Trial.WebAPI.Controllers;
using SparkEquation.Trial.WebAPI.Data.Models;
using Moq;
using SparkEquation.Trial.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APITests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestMethod]
        public void GetById()
        {
            // Arrange
            var mock = new Mock<IProductsService>();
            mock.Setup(repo => repo.GetProductById(1)).Returns(GetProduct());
            var controller = new ProductController(mock.Object);

            // Act
            var result = controller.Get(1);
            var testData = new JsonResult(GetProduct());

            // Assert
            var resultName = ((Product)((JsonResult)result).Value).Name;
            var testName = ((Product)((JsonResult)testData).Value).Name;

            Assert.AreEqual(resultName, testName);
        }

        private Product GetProduct()
        {
            var product = new Product
            {
                Id = 1,
                Name = "TEST UPDATED",
                Featured = true,
                ExpirationDate = new DateTime(),
                ItemsInStock = 0,
                ReceiptDate = new DateTime(),
                Rating = 0,
                BrandId = 1,
                Brand = null,
                CategoryProducts = null
            };

            return product;
        }
    }
}
