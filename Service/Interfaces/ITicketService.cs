using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface ITicketService
    {
        Task<IBaseResponse<IEnumerable<Ticket>>> GetTickets();
        Task<IBaseResponse<bool>> Create(TicketViewModel ticket);
        Task<IBaseResponse<bool>> DeleteById(int id);
        Task<IBaseResponse<bool>> UpdateById(int id, TicketViewModel ticket);
    }
}
