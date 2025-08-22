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
        public async Task<IActionResult> AddScheduling([FromBody] SchedulingDTO dto)
        {
            var result = await _service.CreateNewScheduleingAsync(dto);
            if (dto == null) return BadRequest("Nome Inválido");

            return Ok(new ApiResponse<SchedulingResponseDTO>
            {
                Success = true,
                Message = "Agendamento realizado com sucesso!",
                Data = result
            });
        }

        [HttpDelete("schedulings/id:int")]
        public async Task<IActionResult> DeleteScheduling(int id)
        {
            var result = await _service.DeleteSchedulingByIdAsync(id);
            if (!result)
                return NotFound("Id Invalido");

            return Ok(new ApiResponse<Service>
            {
                Success = true,
                Message = "Agendamento deletado com sucesso",
                Data = null
            });
        }

        [HttpGet("schedulings")]
        public async Task<IActionResult> GetAllScheduling()
        {
            var result = await _service.GetAllSchedulingsAsync();
            if (result == null) return NotFound("Não ha agendamento cadastrados");

            return Ok(result);

        }

        [HttpGet("schedulings/id:int")]
        public async Task<IActionResult> GetIdScheduling(int id)
        {
            var result = await _service.GetSchedulingByIdAsync(id);
            if (result == null) return NotFound("Agendamento nao encontrado");

            return Ok(result);
        }

        [HttpPut("schedulings/id:int")]
        public async Task<IActionResult> UpdateScheduling(int id, [FromBody] Scheduling upscheduling)
        {
            var result = await _service.UpdateSchedulingByIdAsync(id, upscheduling);
            if (!result) return BadRequest();

            return Ok(new ApiResponse<Scheduling>
            {
                Success = true,
                Message = "Agendamento atualizado com sucesso",
                Data = upscheduling
            });
        }

        [HttpGet("schedulings/today")]
        public async Task<IActionResult> GetTodayScheduling()
        {
            var today = DateTime.UtcNow.Date;
            var schedulings = await _service.GetSchedulingByDay(today);
            if (schedulings == null || !schedulings.Any())
                return BadRequest("Nenhum agendamento para hoje");

            return Ok(schedulings);
        }

        [HttpGet("schedulings/day/{date}")]
        public async Task<IActionResult> GetSchedulingByDay(DateTime date)
        {
            var schedulings = await _service.GetSchedulingByDay(date);
            if (schedulings == null || !schedulings.Any())
                return BadRequest("Não ha agendamentos para esse dia");

            return Ok(schedulings);

        }


    }
}