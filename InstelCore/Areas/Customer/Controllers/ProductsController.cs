using InstelCore.Contracts;
using InstelCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository productRepository, ILogger<ProductsController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet]
        [ProducesDefaultResponseType()]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                return Ok(_productRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return null;
            }
        }

        /*[HttpGet]
        public JsonResult Get()
        {
            try
            {
                return Json(_productRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return Json("Bad Request");
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productRepository.GetAll());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products);
            }
        }*/
    }
}
