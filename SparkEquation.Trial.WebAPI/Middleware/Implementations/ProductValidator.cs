using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Middleware.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparkEquation.Trial.WebAPI.Middleware.Implementations
{
    /// <summary>
    /// Product validation
    /// </summary>
    public class ProductValidator : IProductValidator
    {
        /// <summary>
        /// Max category products count
        /// </summary>
        private const int MAX_CATEGORYPRODUCTS_COUNT = 5;

        /// <summary>
        /// Difference between now and expire date
        /// </summary>
        private const int EXPIRE_DAYS_DIFFERENCE = 30;

        /// <summary>
        /// The value of product rating to make it featured = true
        /// </summary>
        private const int FEATURED_RATING = 8;

        /// <summary>
        /// Check if product is valid to create/update
        /// </summary>
        /// <param name="product">Product for validation</param>
        /// <returns>Valid or no</returns>
        public bool IsValid(Product product)
        {
            var isValid = true;

            if (product == null)
            {
                isValid = false;
                return isValid;
            }

            // A product can have from 1 to 5 categories.
            if (product.CategoryProducts.Count == 0 || product.CategoryProducts.Count > MAX_CATEGORYPRODUCTS_COUNT)
            {
                isValid = false;
                return isValid;
            }

            // If a product has an expiration date it should expire not less than 30 days since now
            if (product.ExpirationDate.HasValue)
            {
                // Already expired
                if (product.ExpirationDate.Value < DateTime.Now)
                {
                    isValid = false;
                    return isValid;
                }

                var differenceInDays = (DateTime.Now - product.ExpirationDate.Value).Days; 
                if (differenceInDays < EXPIRE_DAYS_DIFFERENCE)
                {
                    isValid = false;
                    return isValid;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Check product rating if neccessary and actualize featuring
        /// If a product rating is greater than 8 it should automatically become “featured” product.
        /// </summary>
        /// <param name="product">Product</param>
        /// <returns>Actualized product</returns>
        public Product ActualizeFeaturing(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            if (product.Rating > FEATURED_RATING)
            {
                product.Featured = true;
            }

            return product;
        }
    }
}
