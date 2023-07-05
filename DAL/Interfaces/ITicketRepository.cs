using Domain.Enitity;

namespace DAL.Interfaces
{
    public interface ITicketRepository : IBaseRepository<Ticket> 
    {
        Task<Ticket> GetByPatientFIO(string FIO);
        Task<Ticket> GetByDoctorFIO(string FIO);
    }
}
