using DAL.Interfaces;
using Domain.Enitity;

using Service.Interfaces;

namespace Service.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            var doctors = await _doctorRepository.Select();
            return doctors;
        }

        public async Task<bool> CreateAsync(DoctorViewModel doctor)
        {

            var Doctor = new Doctor()
            {
                FIO = doctor.FIO,
                Post = doctor.Post,
                RoomNumber = doctor.RoomNumber,
                WorkTimeStart = doctor.WorkTimeStart,
                WorkTimeEnd = doctor.WorkTimeEnd,
            };
            await _doctorRepository.Create(Doctor);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var model = await _doctorRepository.GetById(id);
            await _doctorRepository.Delete(model);
            return true;
        }

        public async Task<bool> UpdateByIdAsync(int id, DoctorViewModel doctor)
        {
            var model = await _doctorRepository.GetById(id);
            model.FIO = doctor.FIO;
            model.Post = doctor.Post;
            model.RoomNumber = doctor.RoomNumber;
            model.WorkTimeStart = doctor.WorkTimeStart;
            model.WorkTimeEnd = doctor.WorkTimeEnd;
            await _doctorRepository.Update(model);
            return true;
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            var model = await _doctorRepository.GetById(id);
            return model;
        }

        public async Task<Doctor> GetDoctorByFIOAsync(string FIO)
        {
            var model = await _doctorRepository.GetByFIO(FIO);
            return model;
        }
    }
}
