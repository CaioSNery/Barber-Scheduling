using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Interfaces;
using Barber.Models;
using Microsoft.AspNetCore.Mvc;

namespace Barber.Controllers
{
    [ApiController]
    [Route("v1")]
    public class ServiceController : ControllerBase
    {
        private readonly IServicesService _service;

        public ServiceController(IServicesService service)
        {
            _service = service;
        }

        [HttpPost("services")]
        public async Task<IActionResult> CreateService([FromBody] Service service)
        {
            var result = await _service.CreateTypeServiceAsync(service);
            if (result == null) return BadRequest("Invalid Service");
            return Ok(result);
        }

        [HttpDelete("services/{id:int}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var user = await _service.DeleteServiceAsync(id);
            if (!user) return NotFound();

            return Ok("Serviço deletado !");
        }
        [HttpGet("services")]
        public async Task<IActionResult> GetServices()
        {
            var result = await _service.GetServices();
            return Ok(result);
        }



    }
}