﻿using JobBoardPlatform.BLL.Services.Authorization.Policies.IdentityProviders;
using JobBoardPlatform.DAL.Models.Contracts;
using Microsoft.AspNetCore.Http;

namespace JobBoardPlatform.BLL.Services.Authorization.Contracts
{
    public interface IIdentityServiceWithProvider<T> where T : IUserIdentityEntity
    {
        Task<T> TryLoginOrRegisterAsync(HttpContext httpContext, IIdentityProviderClaimKeys claimKeys);
    }
}