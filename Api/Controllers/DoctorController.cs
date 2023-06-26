using Domain.Enitity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections;
using System.Formats.Asn1;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> GetDoctors()
        {
            var response = await _service.GetDoctors();

            return Ok(response);

        }

        [HttpGet]
        [Route("/[controller]/GetDoctor")]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> GetDoctor(int id)
        {
            var response = await _service.GetDoctorById(id);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "MainAdmin, MainDoctor")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var response = await _service.DeleteById(id);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "MainAdmin, MainDoctor")]
        public async Task<IActionResult> Create(DoctorViewModel model)
        {
            var response = await _service.Create(model);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "MainAdmin,MainDoctor")]
        public async Task<IActionResult> UpdateById(int id, DoctorViewModel model)
        {
            var response = await _service.UpdateById(id, model);
            return  Ok(response);
        }
    }
}
