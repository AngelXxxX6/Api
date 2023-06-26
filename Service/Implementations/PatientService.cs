using DAL.Interfaces;
using Domain.Enitity;
using Domain.Enum;
using Domain.Response;
using Service.Interfaces;

namespace Service.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;
        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }


        public async Task<IEnumerable<Patient>> GetPatients()
        {
            
                var patients = await _patientRepository.Select();

                return patients;

            
           
        }

        public async Task<bool> Create(PatientViewModel patient)
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

        public async Task<bool> DeleteById(int id)
        {
           
                var model = await _patientRepository.GetById(id);
            await _patientRepository.Delete(model);
            return true;
                
               
            
           
        }

        public async Task<bool> UpdateById(int id, PatientViewModel patient)
        {
            var baseResponse = new BaseResponse<bool>();
            
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

        public async Task<Patient> GetPatientById(int id)
        {
            var model = await _patientRepository.GetById(id);
            return model;
        }
    }
    }

