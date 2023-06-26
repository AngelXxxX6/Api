using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTickets();
        Task<bool> Create(TicketViewModel ticket);
        Task<bool> DeleteById(int id);
        Task<Ticket> GetById(int id);
        Task<bool> UpdateById(int id, TicketViewModel ticket);
    }
}
