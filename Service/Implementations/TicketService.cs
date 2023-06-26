using DAL.Interfaces;
using Domain.Enitity;
using Domain.Enum;
using Domain.Response;
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


        public async Task<IEnumerable<Ticket>> GetTickets()
        {
           
               var tickets = await _ticketRepository.Select();
               return tickets;
                                    
            
        }

        public async Task<bool> Create(TicketViewModel ticket)
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
        public async Task<bool> DeleteById(int id)
        {
           
                var model = await _ticketRepository.GetById(id);
                await _ticketRepository.Delete(model);
                return true;
               
            
            
        }

        public async Task<bool> UpdateById(int id, TicketViewModel ticket)
        {
           
                var model = await _ticketRepository.GetById(id);

                
                model.PatientFIO = ticket.PatientFIO;
                model.DoctorFIO = ticket.DoctorFIO;
                model.DateTimeTicket = ticket.DateTimeTicket;
            await _ticketRepository.Update(model);
                return true;
            
            
        }

        public async Task<Ticket> GetById(int id)
        {
            var model =await _ticketRepository.GetById(id);
            return model;
        }
    }
}
