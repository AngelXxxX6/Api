using Domain.Enitity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetPatients()
        {

            var response = await _service.GetPatients();
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteById(int id)
        {

            var response = await _service.DeleteById(id);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetPatient");
            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Create(PatientViewModel model)
        {
            var response = await _service.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetPatient");

            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> UpdateById(int id, PatientViewModel model)
        {
            var response = await _service.UpdateById(id, model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetPatients");



            }
            return RedirectToAction("Error");


        }
    }
}
