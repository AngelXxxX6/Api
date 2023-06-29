using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors();
        Task<bool> Create(DoctorViewModel doctor);
        Task<Doctor> GetDoctorById(int id);

        Task<bool> DeleteById(int id);
        Task<bool> UpdateById(int id, DoctorViewModel doctor);
    }
}
