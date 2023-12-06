using Domain.Enitity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> GetPatientsAsync()
        {
            var response = await _service.GetPatientsAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("/[controller]/GetById")]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> GetPatientByIdAsync(int id)
        {
            var response = await _service.GetPatientByIdAsync(id);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "MainAdmin, MainDoctor, Worker")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> CreateAsync(PatientViewModel model)
        {
            var response = await _service.CreateAsync(model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> UpdateByIdAsync(int id, PatientViewModel model)
        {
            var response = await _service.UpdateByIdAsync(id, model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
