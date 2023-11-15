﻿using Microsoft.AspNetCore.Http;

namespace JobBoardPlatform.BLL.Boundaries
{
    public interface IAttachedResume
    {
        public IFormFile? File { get; set; }
        public string? ResumeUrl { get; set; }
        public string? FileName { get; set; }
        public string? FileSize { get; set; }
    }
}