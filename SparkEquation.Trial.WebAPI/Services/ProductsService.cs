using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SparkEquation.Trial.WebAPI.Data;
using SparkEquation.Trial.WebAPI.Data.Factory;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Middleware.Implementations;
using SparkEquation.Trial.WebAPI.Middleware.Interfaces;
using SparkEquation.Trial.WebAPI.Properties;

namespace SparkEquation.Trial.WebAPI.Services
{
    /// <summary>
    /// Product service for data manipulation
    /// </summary>
    public class ProductsService : IProductsService
    {
        /// <summary>
        /// Factory of db context
        /// </summary>
        private readonly IContextFactory _factory;

        /// <summary>
        /// Product data validator
        /// </summary>
        private readonly IProductValidator _productValidator;

        /// <summary>
        /// Product service constructor 
        /// </summary>
        /// <param name="contextFactory">Factory of db context</param>
        public ProductsService(IContextFactory contextFactory)
        {
            _factory = contextFactory;
            _productValidator = new ProductValidator();
        }

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>List of products</returns>
        public List<Product> GetAllProductsData()
        {
            using (var context = _factory.GetContext())
            {
                return context.Products.ToList();
            }
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">Id of product to get</param>
        /// <returns>Product</returns>
        public Product GetProductById(int id)
        {
            using (var context = _factory.GetContext())
            {
                var result = context.Products.Where(x => x.Id == id).FirstOrDefault();

                return result;
            }
        }

        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">Product to add</param>
        public void AddProduct(Product product)
        {
            using (var context = _factory.GetContext())
            {
                var isValid = _productValidator.IsValid(product);
                if (isValid)
                {
                    // If a product rating is greater than 8 it should automatically become “featured” product.
                    product = _productValidator.ActualizeFeaturing(product);

                    context.Products.Add(product);
                    context.SaveChanges();
                } 
                else
                {
                    throw new Exception(Resources.NotValidProductMessage);
                }
            }
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id">Id of product to delete</param>
        public void DeleteProduct(int id)
        {
            using (var context = _factory.GetContext())
            {
                var productToDelete = context.Products.FirstOrDefault(x => x.Id == id);
                if (productToDelete != null)
                {
                    context.Products.Remove(productToDelete);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            using (var context = _factory.GetContext())
            {
                var isValid = _productValidator.IsValid(product);
                if (isValid)
                {
                    if (context.Products.Any(x => x.Id == product.Id))
                    {
                        // If a product rating is greater than 8 it should automatically become “featured” product.
                        product = _productValidator.ActualizeFeaturing(product);

                        context.Products.Update(product);
                        context.SaveChanges();
                    }
                }
                else
                {
                    throw new Exception(Resources.NotValidProductMessage);
                }
            }
        }
    }
}