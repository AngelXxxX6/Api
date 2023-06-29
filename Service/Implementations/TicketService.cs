using DAL.Interfaces;
using Domain.Enitity;

using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Service.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            var tickets = await _ticketRepository.Select();
            return tickets;
        }

        public async Task<bool> CreateAsync(TicketViewModel ticket)
        {
            var Ticket = new Ticket()
            {
                PatientFIO = ticket.PatientFIO,
                DoctorFIO = ticket.DoctorFIO,
                RoomNumber = ticket.RoomNumber,
                DateTimeTicket = ticket.DateTimeTicket,
            };
            await _ticketRepository.Create(Ticket);
            return true;
        }

        [HttpPost]
        public async Task<bool> DeleteByIdAsync(int id)
        {
            var model = await _ticketRepository.GetById(id);
            await _ticketRepository.Delete(model);
            return true;
        }

        public async Task<bool> UpdateByIdAsync(int id, TicketViewModel ticket)
        {
            var model = await _ticketRepository.GetById(id);

            model.PatientFIO = ticket.PatientFIO;
            model.DoctorFIO = ticket.DoctorFIO;
            model.DateTimeTicket = ticket.DateTimeTicket;
            await _ticketRepository.Update(model);
            return true;
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            var model = await _ticketRepository.GetById(id);
            return model;
        }
    }
}
