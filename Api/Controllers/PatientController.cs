using Domain.Enitity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Api.Controllers
{
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Patient/GetPatients")]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<IEnumerable> GetPatients()
        {
            var response = await _service.GetPatients();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return response.Data;
            }
            return "bad";

        }

        [HttpPost]
        [Authorize(Roles = "Main, MainDoctor, Worker")]
        [Route("/Patient/Delete")]
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
        [Route("Patient/Create")]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<bool> Create(PatientViewModel model)
        {
            var response = await _service.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return true;
            }
            return false;
        }

        [HttpPost]
        [Route("Patient/Update")]
        [Authorize(Roles = "MainAdmin, Worker, MainDoctor")]
        public async Task<bool> UpdateById(int id, PatientViewModel model)
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
