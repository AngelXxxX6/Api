using Domain.Enitity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> GetTickets()
        {
            var response = await _service.GetTickets();
            return Ok(response);

        }

        [HttpDelete]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var response = await _service.DeleteById(id);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> Create(TicketViewModel model)
        {
            var response = await _service.Create(model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> UpdateById(int id, TicketViewModel model)
        {
            var response = await _service.UpdateById(id, model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }
    }
}