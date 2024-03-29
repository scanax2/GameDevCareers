﻿using JobBoardPlatform.BLL.Services.Authentification.Authorization;
using JobBoardPlatform.DAL.Models.Company;
using System.Security.Claims;

namespace JobBoardPlatform.PL.Requirements
{
    public class OfferOwnerOrAdminRequirement : IOfferPassRequirement
    {
        public string IdParameterName { get; }


        public OfferOwnerOrAdminRequirement(string idParameterName)
        {
            this.IdParameterName = idParameterName;
        }

        public OfferOwnerOrAdminRequirement()
        {
            this.IdParameterName = string.Empty;
        }

        public bool IsRequirmentSucceded(JobOffer offer, ClaimsPrincipal user)
        {
            return UserRolesUtils.IsUserOwner(user, offer) || UserRolesUtils.IsUserAdmin(user);
        }
    }
}
