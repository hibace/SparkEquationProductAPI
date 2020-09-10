using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SparkEquation.Trial.WebAPI.Controllers;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace SparkEquation.Trial.WebAPI.Tests
{
    [TestClass]
    public class ProductControllerTests
    {
        [Fact]
        public void IndexReturnsAViewResultWithAListOfUsers()
        {
            // Arrange
            var mock = new Mock<IProductsService>();
            mock.Setup(repo => repo.GetProductById(1)).Returns(GetProduct());
            var controller = new ProductController(mock.Object);

            // Act
            var result = controller.Get(1);

            // Assert
            var viewResult = Assert.IsType<JsonResult>(result);

            var model = Assert.IsAssignableFrom<Product>(viewResult.Value);

            var testData = new JsonResult(GetProduct());
            Assert.NotEqual((Product)testData.Value, model);
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
