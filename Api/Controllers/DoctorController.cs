using Domain.Enitity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Implementations;
using Service.Interfaces;

namespace Api.Controllers
{
    public class DoctorController : Controller
    {

        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        
        public async Task<IActionResult> GetDoctors()
        {

            var response = await _service.GetDoctors();
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
                return RedirectToAction("GetDoctors");
            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Create(string fio,string post,int roomNumber, TimeOnly workTimeStart,TimeOnly workTimeEnd)
        {
            
            var response = await _service.Create(new DoctorViewModel
            {
                FIO = fio,Post = post,RoomNumber = roomNumber,WorkTimeStart = workTimeStart,WorkTimeEnd = workTimeEnd
            });
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetDoctors");

            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> UpdateById(int id,DoctorViewModel model)
        {
            
            var response = await _service.UpdateById(id,model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetDoctors");

            }
            return RedirectToAction("Error");

        }
    }
}
