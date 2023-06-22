using Domain.Enitity;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Api.Controllers
{
    public class TicketController : Controller
    {

        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        public async Task<IActionResult> GetTickets()
        {

            var response = await _service.GetTickets();
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
                return RedirectToAction("GetTickets");
            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> Create(TicketViewModel model)
        {
            var response = await _service.Create(model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetTickets");

            }
            return RedirectToAction("Error");
        }

        public async Task<IActionResult> UpdateById(int id, TicketViewModel model)
        {
            var response = await _service.UpdateById(id, model);
            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetTickets");


                
            }
            return RedirectToAction("Error");


        }

    }
}
