using Domain.Enitity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

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
        public async Task<IActionResult> GetTicketsAsync()
        {
            var response = await _service.GetTicketsAsync();
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> CreateAsync(TicketViewModel model)
        {
            var response = await _service.CreateAsync(model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> UpdateByIdAsync(int id, TicketViewModel model)
        {
            var response = await _service.UpdateByIdAsync(id, model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
