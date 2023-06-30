﻿using JobBoardPlatform.BLL.Commands.Contracts;
using Microsoft.AspNetCore.Http;

namespace JobBoardPlatform.IntegrationTests.Common.Mocks.DataStructures
{
    public class AttachedResumeMock : IAttachedResume
    {
        public IFormFile? File { get; set; }
        public string? ResumeUrl { get; set; }
        public string? FileName { get; set; }
        public string? FileSize { get; set; }
    }
}