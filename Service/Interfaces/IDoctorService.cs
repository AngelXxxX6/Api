using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<bool> CreateAsync(DoctorViewModel doctor);
        Task<Doctor> GetDoctorByIdAsync(int id);

        Task<bool> DeleteByIdAsync(int id);
        Task<bool> UpdateByIdAsync(int id, DoctorViewModel doctor);
    }
}
