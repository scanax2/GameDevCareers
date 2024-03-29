﻿using FluentValidation;
using JobBoardPlatform.BLL.DTOs;
using JobBoardPlatform.BLL.Commands.Identities;
using JobBoardPlatform.BLL.Commands.Identity;
using JobBoardPlatform.BLL.Commands.Offer;
using JobBoardPlatform.BLL.Commands.Profile;
using JobBoardPlatform.BLL.Query.Identity;
using JobBoardPlatform.BLL.Services.AccountManagement.Common;
using JobBoardPlatform.BLL.Services.AccountManagement.Password;
using JobBoardPlatform.BLL.Services.AccountManagement.Password.Tokens;
using JobBoardPlatform.BLL.Services.AccountManagement.Registration.Tokens;
using JobBoardPlatform.BLL.Services.Authentification.Contracts;
using JobBoardPlatform.BLL.Services.Authentification.Register;
using JobBoardPlatform.BLL.Services.Email;
using JobBoardPlatform.BLL.Services.IdentityVerification.Contracts;
using JobBoardPlatform.DAL.Models.Admin;
using JobBoardPlatform.DAL.Models.Company;
using JobBoardPlatform.DAL.Models.Employee;
using JobBoardPlatform.PL.Aspects.DataValidators;
using JobBoardPlatform.PL.Aspects.DataValidators.Offers;
using JobBoardPlatform.PL.Aspects.DataValidators.Profile;
using JobBoardPlatform.PL.Aspects.DataValidators.Registration;
using JobBoardPlatform.PL.Controllers.Presenters;
using JobBoardPlatform.PL.Interactors.Registration;
using JobBoardPlatform.PL.ViewModels.Models.Authentification;
using JobBoardPlatform.PL.ViewModels.Models.Registration;

namespace JobBoardPlatform.PL.Configuration
{
    public static class AccountServiceExtensions
    {
        public static void AddAccountServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            AddEmailServices(services, configuration);
            AddPasswordServices(services);
            AddValidatorServices(services);
            AddRegistrationServices(services);
            AddRestorePasswordServices(services);
            AddAccountManagerServices(services);
            AddAdminServices(services);
        }

        private static void AddEmailServices(IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            services.Configure<EmailConfiguration>(configuration.GetSection("EmailGateway"));

            services.AddScoped<IViewRenderService, ViewRenderService>();
            services.AddScoped<IRegistrationEmailSender, RegistrationEmailSender>();
            services.AddScoped<IApplicationsEmailSender, ApplicationsEmailSender>();
            services.AddScoped<IResetPasswordEmailSender, ResetPasswordEmailSender>();
        }

        private static void AddPasswordServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher, MD5Hasher>();
            services.AddTransient<IPasswordGenerator, PasswordGenerator>();
        }

        private static void AddValidatorServices(IServiceCollection services)
        {
            services.AddScoped<IValidator<UserRegisterViewModel>, UserRegisterValidator>();
            services.AddScoped<IValidator<CompanyRegisterViewModel>, CompanyRegisterValidator>();
            services.AddScoped<IValidator<CompanyPublishOfferAndRegisterViewModel>, CompanyPublishOfferAndRegisterValidator>();
            services.AddScoped<IValidator<UserPasswordViewModel>, UserPasswordValidator>();
            services.AddScoped<IValidator<OfferData>, OfferFormDataValidator>();
            services.AddScoped<IValidator<ProfileImage>, ProfileImageValidator>();
        }

        private static void AddRegistrationServices(IServiceCollection services)
        {
            services.AddScoped<IConfirmationLinkFactory, ConfirmationLinkFactory>();

            services.AddTransient<IEmailEmployeeRegistrationService, EmailEmployeeRegistrationService>();
            services.AddTransient<IEmailCompanyRegistrationService, EmailCompanyRegistrationService>();
            services.AddTransient<EmailCompanyPublishOfferAndRegistrationService>();
            services.AddTransient(typeof(IRegistrationService<>), typeof(RegistrationService<>));
            services.AddTransient<IRegistrationTokensService, RegistrationTokensService>();

            services.AddTransient<IRegistrationInteractor<UserRegisterViewModel>, EmailEmployeeRegistrationInteractor>();
            services.AddTransient<IRegistrationInteractor<CompanyRegisterViewModel>, EmailCompanyRegistrationInteractor>();
            services.AddTransient<EmailCompanyPublishOfferAndRegistrationInteractor>();

            services.AddTransient(typeof(DataTokensService<>));
            services.AddTransient<ConfirmationTokensService>();
        }

        private static void AddRestorePasswordServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IResetPasswordService<,>), typeof(ResetPasswordService<,>));
            services.AddTransient<IRestorePasswordTokensService, RestorePasswordTokensService>();
        }

        private static void AddAccountManagerServices(IServiceCollection services)
        {
            services.AddTransient<IdentityQueryExecutor<EmployeeIdentity>>();
            services.AddTransient<IdentityQueryExecutor<CompanyIdentity>>();
            services.AddTransient<IdentityQueryExecutor<AdminIdentity>>();

            services.AddTransient<UserManager<EmployeeIdentity>>();
            services.AddTransient<UserManager<CompanyIdentity>>();
            services.AddTransient<UserManager<AdminIdentity>>();

            services.AddTransient<IUserSettingsService, UserSettingsService>();
            services.AddTransient<IDeleteUserCommandFactory, DeleteUserCommandFactory>();
            services.AddTransient<IUpdateUserCommandFactory, UpdateUserCommandFactory>();

            services.AddTransient(typeof(IModifyIdentityService<>), typeof(ModifyIdentityService<>));
        }

        private static void AddAdminServices(IServiceCollection services)
        {
            services.AddTransient<AdminCommands>();
        }
    }
}
