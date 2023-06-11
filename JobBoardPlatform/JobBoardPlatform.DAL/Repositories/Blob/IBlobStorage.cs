﻿using Microsoft.AspNetCore.Http;

namespace JobBoardPlatform.DAL.Repositories.Blob
{
    public interface IBlobStorage
    {
        Task<string> AddAsync(IFormFile newFile);
        Task<string> UpdateAsync(string? path, IFormFile newFile);
        Task DeleteAsync(string path);
        Task<FileMetadata> GetBlobMetadataAsync(string? path);
        Task<bool> IsExistsAsync(string? path);
    }
}
