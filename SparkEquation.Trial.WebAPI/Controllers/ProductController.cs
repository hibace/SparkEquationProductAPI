using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SparkEquation.Trial.WebAPI.Data.Models;
using SparkEquation.Trial.WebAPI.Services;

namespace SparkEquation.Trial.WebAPI.Controllers
{
    /// <summary>
    /// Controller for Product entity
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productsService;
        
        /// <summary>
        /// Product controller constructor
        /// </summary>
        /// <param name="productsService">Product service to manipulate in db</param>
        public ProductController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        // GET api/product
        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns>Collection of product</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = _productsService.GetAllProductsData();
                return new JsonResult(results);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/product/5
        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="id">Identifier of product row</param>
        /// <returns>Product</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var product = _productsService.GetProductById(id);

                if (product == null)
                {
                    return NotFound();
                }

                return new JsonResult(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/product/1
        /// <summary>
        /// Add new product
        /// </summary>
        /// <param name="product">Product to add</param>
        /// <returns>Added Product</returns>
        [HttpPost]
        public IActionResult Post(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }

                _productsService.AddProduct(product);

                return new JsonResult(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/product/
        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="product">Product to update</param>
        /// <returns>Updated product</returns>
        [HttpPut]
        public IActionResult Put(Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest();
                }

                _productsService.UpdateProduct(product);

                return new JsonResult(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/product/1
        /// <summary>
        /// Delete product by Id
        /// </summary>
        /// <param name="id">Id of product to delete</param>
        /// <returns>Statuscode Ok</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _productsService.DeleteProduct(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}