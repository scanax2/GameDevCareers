﻿using JobBoardPlatform.BLL.Services.Session;
using JobBoardPlatform.DAL.Models.Employee;
using JobBoardPlatform.DAL.Repositories.Blob;
using JobBoardPlatform.DAL.Repositories.Models;
using Microsoft.AspNetCore.Http;

namespace JobBoardPlatform.BLL.Commands.Profile
{
    public class DeleteEmployeeResumeCommand : ICommand
    {
        private readonly int id;
        private readonly IRepository<EmployeeProfile> repository;
        private readonly IBlobStorage resumeStorage;
        private readonly HttpContext httpContext;


        public DeleteEmployeeResumeCommand(int id, 
            IRepository<EmployeeProfile> repository,
            IBlobStorage resumeStorage,
            HttpContext httpContext)
        {
            this.id = id;
            this.repository = repository;
            this.resumeStorage = resumeStorage;
            this.httpContext = httpContext;
        }

        public async Task Execute()
        {
            var profile = await repository.Get(id);

            await resumeStorage.DeleteAsync(profile.ResumeUrl!);
            profile.ResumeUrl = null;

            await repository.Update(profile);

            var userSession = new UserSessionService<EmployeeProfile>(httpContext);
            await userSession.UpdateSessionStateAsync(profile);
        }
    }
}