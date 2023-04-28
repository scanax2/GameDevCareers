﻿using JobBoardPlatform.BLL.Models.Contracts;
using JobBoardPlatform.DAL.Models.Company;
using JobBoardPlatform.DAL.Repositories.Blob;
using JobBoardPlatform.DAL.Repositories.Models;
using Microsoft.AspNetCore.Http;

namespace JobBoardPlatform.BLL.Commands.Profile
{
    public class UpdateCompanyProfileCommand : UpdateProfileCommandBase<CompanyProfile, ICompanyProfileData>
    {
        private readonly IBlobStorage userProfileImagesStorage;


        public UpdateCompanyProfileCommand(int profileId, 
            ICompanyProfileData profileData, 
            IRepository<CompanyProfile> repository,
            HttpContext httpContext,
            IBlobStorage userProfileImagesStorage) 
            : base(profileId, profileData, repository, httpContext)
        {
            this.userProfileImagesStorage = userProfileImagesStorage;
        }

        protected override async Task UploadFiles(ICompanyProfileData from, CompanyProfile to)
        {
            if (from.ProfileImage != null)
            {
                var imageUrl = await userProfileImagesStorage.UpdateAsync(to.ProfileImageUrl, from.ProfileImage);
                to.ProfileImageUrl = imageUrl;
            }
        }

        protected override void MapDataToModel(ICompanyProfileData from, CompanyProfile to)
        {
            if (!string.IsNullOrEmpty(from.CompanyName))
            {
                to.CompanyName = from.CompanyName;
            }
            if (!string.IsNullOrEmpty(from.ProfileImageUrl))
            {
                to.ProfileImageUrl = from.ProfileImageUrl;
            }

            to.City = from.City;
            to.Country = from.Country;
            to.CompanyWebsiteUrl = from.CompanyWebsiteUrl;
        }
    }
}
