using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DEMO_PT.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _productService.Getall());
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _productService.Get(id));
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Product model)
        {
            return Ok(await _productService.Add(model));
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id,[FromBody] Product model)
        {
            return Ok(await _productService.Update(model));
        }
        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _productService.Delete(id));
        }
    }
}
