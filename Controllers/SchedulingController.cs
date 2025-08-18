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
    public class SchedulingController : ControllerBase
    {
        private readonly ISchedulingService _service;
        public SchedulingController(ISchedulingService service)
        {
            _service = service;
        }

        [HttpPost("schedulings")]
        public async Task<IActionResult> AddScheduling([FromBody] Scheduling scheduling)
        {
            var result = await _service.CreateNewScheduleingAsync(scheduling);
            if (scheduling == null) return BadRequest("Nome Inválido");

            return Ok(new ApiResponse<Scheduling>
            {
                Success = true,
                Message = "Agendamento realizado com sucesso!",
                Data = scheduling
            });
        }


    }
}