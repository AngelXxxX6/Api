using Domain.Enitity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

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
        public async Task<IActionResult> GetDoctorsAsync()
        {
            var response = await _service.GetDoctorsAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("/[controller]/GetDoctor")]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IActionResult> GetDoctorAsync(int id)
        {
            var response = await _service.GetDoctorByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        [Route("/[controller]/GetDoctorByFIO")]
        [Authorize(Roles = "MainAdmin, MainDoctor")]
        public async Task<IActionResult> GetDoctorByFIOAsync(string FIO)
        {
            var response = await _service.GetDoctorByFIOAsync(FIO);
            return Ok(response);
        }

        [HttpDelete]
        [Authorize(Roles = "MainAdmin, MainDoctor")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var response = await _service.DeleteByIdAsync(id);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "MainAdmin, MainDoctor")]
        public async Task<IActionResult> CreateAsync(DoctorViewModel model)
        {
            var response = await _service.CreateAsync(model);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "MainAdmin,MainDoctor")]
        public async Task<IActionResult> UpdateByIdAsync(int id, DoctorViewModel model)
        {
            var response = await _service.UpdateByIdAsync(id, model);
            return Ok(response);
        }
    }
}
