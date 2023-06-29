﻿using Domain.Enitity.AccountViewsModel;
using Domain.Response;
using System.Security.Claims;

namespace Service.Interfaces
{
    public interface IAccountService
    {
        Task<bool> Register(RegisterViewModel model);
        Task<ClaimsIdentity> Login(LoginViewModel model);
    }
}
