﻿using Azure.Storage.Blobs.Models;
using JobBoardPlatform.DAL.Options;
using Microsoft.Extensions.Options;

namespace JobBoardPlatform.DAL.Repositories.Blob
{
    public class UserProfileImagesStorage : CoreBlobStorage
    {
        private const string ContainerName = "userprofileimagescontainer";

        private readonly BlobHttpHeaders blobHttpHeaders;


        public UserProfileImagesStorage(IOptions<AzureOptions> azureOptions) : base(azureOptions)
        {
            blobHttpHeaders = new BlobHttpHeaders()
            {
                ContentType = "image/bitmap"
            };
        }

        protected override string GetContainerName()
        {
            return ContainerName;
        }

        protected override BlobHttpHeaders GetBlobHttpHeaders()
        {
            return blobHttpHeaders;
        }
    }
}