using DAL.Interfaces;
using Domain.Enitity;

using Service.Interfaces;

namespace Service.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IAppointmentRepository _patientRepository;

        public PatientService(IAppointmentRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            var patients = await _patientRepository.Select();
            return patients;
        }

        public async Task<bool> CreateAsync(PatientViewModel patient)
        {
            var Patient = new Patient()
            {
                FIO = patient.FIO,
                Adress = patient.Adress,
                Phone = patient.Phone,
                DateBirthday = patient.DateBirthday,
            };
            await _patientRepository.Create(Patient);
            return true;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            var model = await _patientRepository.GetById(id);
            await _patientRepository.Delete(model);
            return true;
        }

        public async Task<bool> UpdateByIdAsync(int id, PatientViewModel patient)
        {


            var model = await _patientRepository.GetById(id);
            if (model == null)
            {
                return false;
            }
            model.FIO = patient.FIO;
            model.Adress = patient.Adress;
            model.Phone = patient.Phone;
            model.DateBirthday = patient.DateBirthday;
            await _patientRepository.Update(model);
            return true;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var model = await _patientRepository.GetById(id);
            return model;
        }
    }
}
