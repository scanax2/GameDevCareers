﻿using JobBoardPlatform.DAL.Models.Company;
using JobBoardPlatform.DAL.Models.Employee;
using JobBoardPlatform.DAL.Repositories.Blob.AttachedResume;
using JobBoardPlatform.DAL.Repositories.Blob;
using JobBoardPlatform.DAL.Repositories.Models;
using JobBoardPlatform.BLL.Commands.Offer;
using JobBoardPlatform.DAL.Models.Admin;

namespace JobBoardPlatform.BLL.Commands.Identities
{
    public class DeleteUserCommandFactory : IDeleteUserCommandFactory
    {
        private readonly IRepository<EmployeeIdentity> employeeIdentityRepository;
        private readonly IRepository<EmployeeProfile> employeeProfileRepository;
        private readonly IRepository<CompanyIdentity> companyIdentityRepository;
        private readonly IRepository<CompanyProfile> companyProfileRepository;
        private readonly IRepository<AdminIdentity> adminIdentityRepository;
        private readonly IUserProfileImagesStorage imagesStorage;
        private readonly IProfileResumeBlobStorage resumesStorage;
        private readonly IOfferManager offerManager;


        public DeleteUserCommandFactory(
            IRepository<EmployeeIdentity> employeeIdentityRepository,
            IRepository<EmployeeProfile> employeeProfileRepository,
            IRepository<CompanyIdentity> companyIdentityRepository,
            IRepository<CompanyProfile> companyProfileRepository,
            IRepository<AdminIdentity> adminIdentityRepository,
            IUserProfileImagesStorage imagesStorage,
            IProfileResumeBlobStorage resumesStorage,
            IOfferManager offerManager)
        {
            this.employeeIdentityRepository = employeeIdentityRepository;
            this.employeeProfileRepository = employeeProfileRepository;
            this.companyIdentityRepository = companyIdentityRepository;
            this.companyProfileRepository = companyProfileRepository;
            this.adminIdentityRepository = adminIdentityRepository;
            this.imagesStorage = imagesStorage;
            this.resumesStorage = resumesStorage;
            this.offerManager = offerManager;
        }

        public ICommand GetCommand(Type identityType, int id)
        {
            if (identityType == typeof(EmployeeIdentity))
            {
                return GetDeleteEmployeeCommand(id);
            }
            else if (identityType == typeof(CompanyIdentity))
            {
                return GetDeleteCompanyCommand(id);
            }
            else if (identityType == typeof(AdminIdentity))
            {
                return GetDeleteAdminCommand(id);
            }
            throw new Exception("Unknown user identity type");
        }

        private ICommand GetDeleteEmployeeCommand(int id)
        {
            return new DeleteEmployeeCommand(
                employeeIdentityRepository, employeeProfileRepository, imagesStorage, resumesStorage, id);
        }

        private ICommand GetDeleteCompanyCommand(int id)
        {
            return new DeleteCompanyCommand(
                companyIdentityRepository, companyProfileRepository, offerManager, imagesStorage, id);
        }

        private ICommand GetDeleteAdminCommand(int id)
        {
            return new DeleteAdminCommand(adminIdentityRepository, id);
        }
    }
}
