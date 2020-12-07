using InstelCore.Contracts;
using InstelCore.Data;
using InstelCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstelCore.Areas.Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public OrdersController(IProductRepository productRepository, ILogger<OrdersController> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productRepository.GetAllOrders());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed : {ex}");
                return BadRequest("Failed");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _productRepository.GetOrderById(id);

                if (order != null) return Ok(order);
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed : {ex}");
                return BadRequest("Failed");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newOrder = new Order()
                    {
                        OrderDate = model.OrderDate,
                        OrderNumber = model.OrderNumber,
                        Id = model.Id
                    };

                    if(newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }

                    if (_productRepository.SaveAll())
                    {
                        var ordervm = new OrderVM
                        {
                            OrderDate = model.OrderDate,
                            OrderNumber = model.OrderNumber,
                            Id = model.Id
                        };

                        return Created($"/api/orders/{ordervm.Id}", model);
                    }

                    _productRepository.AddEntity(model);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed : {ex}");
            }
            return BadRequest("Failed to save new order");
            //add it to the db
            //return Ok();
        }
    }
}
