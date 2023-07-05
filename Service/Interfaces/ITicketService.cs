using Domain.Enitity;


namespace Service.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync();
        Task<bool> CreateAsync(TicketViewModel ticket);
        Task<bool> DeleteByIdAsync(int id);
        Task<Ticket> GetByIdAsync(int id);
        Task<Ticket> GetByPatientFIOAsync(string FIO);
        Task<Ticket> GetByDoctorFIOAsync(string FIO);
        Task<bool> UpdateByIdAsync(int id, TicketViewModel ticket);
    }
}
