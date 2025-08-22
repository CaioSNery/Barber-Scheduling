using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barber.Dtos;
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
            return Ok(new ApiResponse<Service>
            {
                Success = true,
                Message = "Serviço adicionado com sucesso!",
                Data = service
            });
        }

        [HttpDelete("services/{id:int}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var user = await _service.DeleteServiceAsync(id);
            if (!user) return NotFound();

            return Ok(new ApiResponse<Service>
            {
                Success = true,
                Message = "Serviço deletado com sucesso!",
                Data = null
            });
        }
        [HttpGet("services")]
        public async Task<IActionResult> GetServices()
        {
            var result = await _service.GetServices();
            return Ok(result);
        }

        [HttpPut("services{id:int}")]
        public async Task<IActionResult> UpdateService(int id, [FromBody] Service servup)
        {
            var result = await _service.UpdateServiceByIdAsync(id, servup);
            if (!result) return BadRequest("Invalid Data");

            return Ok(new ApiResponse<Service>
            {
                Success = true,
                Message = "Serviço atualizado com sucesso",
                Data = servup
            });
        }



    }
}