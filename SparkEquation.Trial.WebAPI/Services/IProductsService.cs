using System.Collections.Generic;
using SparkEquation.Trial.WebAPI.Data.Models;

namespace SparkEquation.Trial.WebAPI.Services
{
    public interface IProductsService
    {
        List<Product> GetAllProductsData();

        Product GetProductById(int id);

        void AddProduct(Product product);

        void DeleteProduct(int id);

        void UpdateProduct(Product product);
    }
}