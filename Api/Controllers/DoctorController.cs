using Domain.Enitity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections;

namespace Api.Controllers
{
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Doctor/GetDoctors")]
        public async Task<IEnumerable> GetDoctors()
        {
            var response = await _service.GetDoctors();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return response.Data;
            }
            return "bad";

        }

        [HttpPost]
        [Route("Doctor/DeleteById")]
        public async Task<bool> DeleteById(int id)
        {
            var response = await _service.DeleteById(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("Doctor/Create")]
        public async Task<bool> Create(DoctorViewModel model)
        {
            var response = await _service.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("Doctor/UpdateById")]
        public async Task<bool> UpdateById(int id, DoctorViewModel model)
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
