using Domain.Enitity;

namespace DAL.Interfaces
{
    public interface IDoctorRepository : IBaseRepository<Doctor> 
    {
        Task<Doctor> GetByFIO(string FIO);
    }
}
