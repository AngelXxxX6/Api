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
        public async Task<IEnumerable> GetTickets()
        {
            var response = await _service.GetTickets();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return response.Data;
            }
            return "bad";

        }

        [HttpDelete]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<bool> DeleteById(int id)
        {
            var response = await _service.DeleteById(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return true;
            }
            return false;
        }

        [HttpPut]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<bool> Create(TicketViewModel model)
        {
            var response = await _service.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<bool> UpdateById(int id, TicketViewModel model)
        {
            var response = await _service.UpdateById(id, model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return true;
            }
            return true;
        }
    }
}