using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync();
        Task<bool> CreateAsync(TicketViewModel ticket);
        Task<bool> DeleteByIdAsync(int id);
        Task<Ticket> GetByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, TicketViewModel ticket);
    }
}
