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
    [Route("clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }


        // GET: api/<ClientController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _clientService.Getall());
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await _clientService.Get(id));
        }

        // POST api/<ClientController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Client model)
        {
            return Ok(await _clientService.Add(model));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Client model)
        {
            return Ok(await _clientService.Update(model));
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await _clientService.Delete(id));
        }
    }
}
