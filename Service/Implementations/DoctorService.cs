using DAL.Interfaces;
using DAL.Repositories;
using Domain.Enitity;
using Domain.Enum;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public async Task<IBaseResponse<IEnumerable<Doctor>>> GetDoctors()
        {
            var baseResponse = new BaseResponse<IEnumerable<Doctor>>();
            try
            {
                var doctors = _doctorRepository.Select().ToList();
                if (doctors.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 докторов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = doctors;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Doctor>>()
                {
                    Description = $"[GetDoctors] : {ex.Message}"
                };
            }
        }
        [HttpPost]
        public async Task<IBaseResponse<bool>> Create(DoctorViewModel doctor)
        {
            var baseResponse = new BaseResponse<bool>();
            try
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
        [HttpPost]
        public async Task<IBaseResponse<bool>> DeleteById(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                if (await _doctorRepository.DeleteById(id))
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
        [HttpPost]
        public async Task<IBaseResponse<bool>> UpdateById(int id, DoctorViewModel doctor)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var model = _doctorRepository.Select().Where(x => x.Id == id).FirstOrDefault();

                if (model == null)
                {
                    baseResponse.Data = false;
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                model.FIO = doctor.FIO;
                model.Post = doctor.Post;
                model.RoomNumber = doctor.RoomNumber;
                model.WorkTimeStart = doctor.WorkTimeStart;
                model.WorkTimeEnd = doctor.WorkTimeEnd;
                if (await _doctorRepository.Update(model))
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
