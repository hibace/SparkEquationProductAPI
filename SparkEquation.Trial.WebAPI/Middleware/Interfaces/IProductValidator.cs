using SparkEquation.Trial.WebAPI.Data.Models;

namespace SparkEquation.Trial.WebAPI.Middleware.Interfaces
{
    /// <summary>
    /// Product validation interface
    /// </summary>
    public interface IProductValidator
    {
        /// <summary>
        /// Check if product is valid to create/update
        /// </summary>
        /// <param name="product">Product for validation</param>
        /// <returns>Valid or no</returns>
        bool IsValid(Product product);

        /// <summary>
        /// Check product rating if neccessary and actualize featuring
        /// If a product rating is greater than 8 it should automatically become “featured” product.
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Actualized product</returns>
        Product ActualizeFeaturing(Product product);
    }
}