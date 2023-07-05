using Domain.Enitity;


namespace Service.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<bool> CreateAsync(DoctorViewModel doctor);
        Task<Doctor> GetDoctorByIdAsync(int id);

        Task<bool> DeleteByIdAsync(int id);
        Task<Doctor> GetDoctorByFIOAsync(string FIO);
        Task<bool> UpdateByIdAsync(int id, DoctorViewModel doctor);
    }
}
