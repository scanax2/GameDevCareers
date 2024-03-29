﻿using JobBoardPlatform.DAL.Repositories.Blob.AttachedResume;
using JobBoardPlatform.DAL.Repositories.Blob;
using JobBoardPlatform.DAL.Repositories.Blob.Settings;
using JobBoardPlatform.IntegrationTests.Common.Fixtures;
using JobBoardPlatform.DAL.Repositories.Blob.Temporary;

namespace JobBoardPlatform.IntegrationTests.Common.Mocks.Services
{
    internal class BlobStorageSettingsMock : IBlobStorageSettings
    {
        private readonly string imagesContainer;
        private readonly string resumeContainer;
        private readonly string applicationsResumeContainer;


        public BlobStorageSettingsMock()
        {
            imagesContainer = TestSetup.GetUniqueName("imagescontainer");
            resumeContainer = TestSetup.GetUniqueName("resumecontainer");
            applicationsResumeContainer = TestSetup.GetUniqueName("applicationsresumecontainer");
        }

        public string GetContainerName(Type storageType)
        {
            if (storageType == typeof(UserProfileImagesStorage))
            {
                return imagesContainer;
            }
            else if (storageType == typeof(UserProfileAttachedResumeStorage))
            {
                return resumeContainer;
            }
            else if (storageType == typeof(UserApplicationsResumeStorage))
            {
                return applicationsResumeContainer;
            }
            throw new NotImplementedException();
        }
    }
}
