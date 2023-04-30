﻿using JobBoardPlatform.BLL.Services.Authorization.Utilities;
using JobBoardPlatform.DAL.Models.Employee;
using JobBoardPlatform.DAL.Repositories.Models;
using JobBoardPlatform.PL.ViewModels.OfferViewModels.Users;
using JobBoardPlatform.PL.ViewModels.Profile.Employee;
using JobBoardPlatform.PL.ViewModels.Utilities.Contracts;
using System.Security.Claims;

namespace JobBoardPlatform.PL.ViewModels.Middleware.Factories.Applications
{
    public class OfferApplicationUpdateViewModelFactory : IFactory<OfferApplicationUpdateViewModel>
    {
        private readonly ClaimsPrincipal user;
        private readonly IRepository<EmployeeIdentity> identityRepository;
        private readonly IRepository<EmployeeProfile> profileRepository;


        public OfferApplicationUpdateViewModelFactory(ClaimsPrincipal user, 
            IRepository<EmployeeIdentity> identityRepository,
            IRepository<EmployeeProfile> profileRepository)
        {
            this.user = user;
            this.identityRepository = identityRepository;
            this.profileRepository = profileRepository;
        }

        public async Task<OfferApplicationUpdateViewModel> Create()
        {
            var update = new OfferApplicationUpdateViewModel();

            // Auto fill form
            int identityId = UserSessionUtils.GetIdentityId(user);

            var identity = await identityRepository.Get(identityId);
            var profile = await profileRepository.Get(identity.ProfileId);

            update.FullName = $"{profile.Name} {profile.Surname}";
            update.Email = identity.Email;

            var attachedResume = new EmployeeAttachedResumeViewModel();
            attachedResume.ResumeUrl = profile.ResumeUrl;
            update.AttachedResume = attachedResume;

            if (profile.Description != null)
            {
                update.AdditionalInformation = profile.Description;
            }

            return update;
        }
    }
}