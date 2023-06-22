using DAL.Interfaces;
using DAL.Repositories;
using Domain.Enitity;
using Domain.Enum;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
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

       
        public async Task<IBaseResponse<IEnumerable<Patient>>> GetPatients()
        {
            var baseResponse = new BaseResponse<IEnumerable<Patient>>();
            try
            {
                var patients =  _patientRepository.Select().ToList();
                if (patients.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 пациентов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = patients;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Patient>>()
                {
                    Description = $"[GetPatients] : {ex.Message}"
                };
            }
        }
       
        public async Task<IBaseResponse<bool>> Create(PatientViewModel patient)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var Patient = new Patient()
                {
                    FIO = patient.FIO,
                    Adress = patient.Adress,
                    Phone = patient.Phone,
                    DateBirthday = patient.DateBirthday,
                };
                await _patientRepository.Create(Patient);
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[Create] : {ex.Message}"
                };
            }
            return baseResponse;
        }
       
        public async Task<IBaseResponse<bool>> DeleteById(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var model = _patientRepository.Select().Where(x => x.Id == id).FirstOrDefault();
                if (await _patientRepository.Delete(model))
                {
                    baseResponse.Data = true;
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }
                else
                { 
                    return new BaseResponse<bool>() 
                    { 
                        Description = $"[DeleteById] : {StatusCode.UserNotFound}" 
                    }; 
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteById] : {ex.Message}"
                };
            }
        }
       
        public async Task<IBaseResponse<bool>> UpdateById(int id, PatientViewModel patient)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var model = _patientRepository.Select().Where(x => x.Id == id).FirstOrDefault();
               
                if (model == null)
                {
                    baseResponse.Data = false;
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                model.FIO = patient.FIO;
                model.Adress = patient.Adress;
                model.Phone = patient.Phone;
                model.DateBirthday = patient.DateBirthday;
                if (await _patientRepository.Update(model))
                {
                    baseResponse.StatusCode = StatusCode.OK;
                    baseResponse.Data = true;
                    return baseResponse;
                }
                else
                {
                    baseResponse.Data = false;
                    baseResponse.StatusCode = StatusCode.InternalServerError;
                    return baseResponse;
                }
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[UpdateById] : {ex.Message}"
                };
            }
        }
    }
}
