using Domain.Enitity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Service.Interfaces;
using System.Collections;

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
        public async Task<IActionResult> GetPatients()
        {
            var response = await _service.GetPatients();
           return Ok(response);

        }

        [HttpGet]
        [Route("/[controller]/GetById")]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var response = await _service.GetPatientById(id);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "MainAdmin, MainDoctor, Worker")]

        public async Task<IActionResult> DeleteById(int id)
        {
            var response = await _service.DeleteById(id);
            if(response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPut]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> Create(PatientViewModel model)
        {
            var response = await _service.Create(model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }

        [HttpPost]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> UpdateById(int id, PatientViewModel model)
        {
            var response = await _service.UpdateById(id, model);
            if (response)
                return Ok(response);
            return BadRequest(response);
        }
    }
}
