using DAL.Interfaces;
using DAL.Repositories;
using Domain.Enitity;
using Domain.Enum;
using Domain.Response;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System.Numerics;

namespace Service.Implementations
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        
        public async Task<IBaseResponse<IEnumerable<Ticket>>> GetTickets()
        {
            var baseResponse = new BaseResponse<IEnumerable<Ticket>>();
            try
            {
                var tickets = _ticketRepository.Select().ToList();
                if (tickets.Count() == 0)
                {
                    baseResponse.Description = "Найдено 0 талонов";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = tickets;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Ticket>>()
                {
                    Description = $"[GetTickets] : {ex.Message}"
                };
            }
        }
     
        public async Task<IBaseResponse<bool>> Create(TicketViewModel ticket)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var Ticket = new Ticket()
                {
                    PatientFIO = ticket.PatientFIO,
                    DoctorFIO = ticket.DoctorFIO,
                    RoomNumber = ticket.RoomNumber,
                    DateTimeTicket = ticket.DateTimeTicket,
                };
                await _ticketRepository.Create(Ticket);
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
                var model = _ticketRepository.Select().Where(x => x.Id == id).FirstOrDefault();
                if (await _ticketRepository.Delete(model))
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
     
        public async Task<IBaseResponse<bool>> UpdateById(int id, TicketViewModel ticket)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var model = _ticketRepository.Select().Where(x => x.Id == id).FirstOrDefault();

                if (model == null)
                {
                    baseResponse.Data = false;
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    return baseResponse;
                }
                model.PatientFIO = ticket.PatientFIO;
                model.DoctorFIO = ticket.DoctorFIO;
                model.DateTimeTicket = ticket.DateTimeTicket;
                if (await _ticketRepository.Update(model))
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
