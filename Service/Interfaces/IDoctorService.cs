using Domain.Enitity;
using Domain.Response;

namespace Service.Interfaces
{
    public interface IDoctorService
    {
        Task<IBaseResponse<IEnumerable<Doctor>>> GetDoctors();
        Task<IBaseResponse<bool>> Create(DoctorViewModel doctor);
        Task<IBaseResponse<bool>> DeleteById(int id);
        Task<IBaseResponse<bool>> UpdateById(int id, DoctorViewModel doctor);
    }
}
