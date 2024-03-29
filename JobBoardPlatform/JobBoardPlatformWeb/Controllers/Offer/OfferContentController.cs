﻿using JobBoardPlatform.DAL.Models.Company;
using JobBoardPlatform.DAL.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using JobBoardPlatform.DAL.Models.Employee;
using JobBoardPlatform.BLL.Services.Actions.Offers.Factory;
using JobBoardPlatform.BLL.Commands.Application;
using JobBoardPlatform.PL.ViewModels.Middleware.Factories.Applications;
using JobBoardPlatform.PL.ViewModels.Models.Offer.Users;
using JobBoardPlatform.PL.ViewModels.Factories.Offer;
using Microsoft.AspNetCore.Authorization;
using JobBoardPlatform.BLL.Query.Identity;
using JobBoardPlatform.DAL.Repositories.Blob.AttachedResume;
using JobBoardPlatform.BLL.Services.Authentification.Authorization;
using JobBoardPlatform.DAL.Repositories.Blob.Metadata;
using FluentValidation;
using JobBoardPlatform.PL.Aspects.DataValidators;
using JobBoardPlatform.PL.Controllers.Presenters;
using JobBoardPlatform.BLL.Commands.Offer;
using JobBoardPlatform.PL.Interactors.Notifications;

namespace JobBoardPlatform.PL.Controllers.Offer
{
    [Authorize(Policy = AuthorizationPolicies.OfferPublishedOrOwnerOnlyPolicy)]
    public class OfferContentController : Controller
    {
        private readonly IApplicationsManager applicationsManager;
        private readonly IOfferManager offerManager;
        private readonly IRepository<JobOffer> offersRepository;
        private readonly IRepository<EmployeeProfile> profileRepository;
        private readonly IRepository<EmployeeIdentity> identityRepository;
        private readonly IProfileResumeBlobStorage resumeStorage;
        private readonly IOfferActionHandlerFactory actionHandlerFactory;
        private readonly IValidator<OfferApplicationUpdateViewModel> applicationFormValidator;
        private readonly IViewRenderService viewRenderService;


        public OfferContentController(
            IApplicationsManager applicationsManager,
            IOfferManager offerManager,
            IRepository<JobOffer> offersRepository,
            IRepository<EmployeeProfile> profileRepository,
            IRepository<EmployeeIdentity> identityRepository,
            IOfferActionHandlerFactory actionHandlerFactory,
            IProfileResumeBlobStorage resumeStorage,
            IValidator<OfferApplicationUpdateViewModel> applicationFormValidator,
            IViewRenderService viewRenderService)
        {
            this.applicationsManager = applicationsManager;
            this.offerManager = offerManager;
            this.offersRepository = offersRepository;
            this.profileRepository = profileRepository;
            this.identityRepository = identityRepository;
            this.resumeStorage = resumeStorage;
            this.actionHandlerFactory = actionHandlerFactory;
            this.applicationFormValidator = applicationFormValidator;
            this.viewRenderService = viewRenderService;
        }

        [Route("{companyname}-{offertitle}-{id}")]
        public async Task<IActionResult> Offer(int id, string companyname, string offertitle)
        {
            var content = new OfferContentViewModel();
            content.Display = await GetOfferContentDisplayViewModel(id);

            await TryFillApplicationForm(content);
            await TryIncreaseViewsCount(id);

            content.Update.OfferId = id;

            return View(content);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{companyname}-{offertitle}-{id}")]
        public async Task<IActionResult> Offer(OfferContentViewModel content)
        {
            var result = await applicationFormValidator.ValidateAsync(content.Update);
            if (result.IsValid)
            {
                int offerId = content.Update.OfferId;
                viewRenderService.SetController(this);

                var actionsHandler = actionHandlerFactory.GetApplyActionHandler(offerId);
                if (!actionsHandler.IsActionDoneRecently(Request))
                {
                    await applicationsManager.PostApplicationFormAsync(
                        offerId, TryGetUserProfileId(), content.Update);

                    actionsHandler.RegisterAction(Request, Response);
                }
                NotificationsManager.Instance.SetSuccessNotification(
                    NotificationsManager.PostApplicationSection,
                    $"Your resume has been submitted successfully!",
                    TempData);
            }
            else
            {
                result.AddToModelState(this.ModelState, nameof(content.Update));
                NotificationsManager.Instance.SetErrorNotification(
                    NotificationsManager.PostApplicationSection,
                    $"Something went wrong.",
                    TempData);
            }

            content.Display = await GetOfferContentDisplayViewModel(content.Update.OfferId);
            return View(content);
        }

        [Route("redirect-to-external")]
        public async Task<IActionResult> RedirectToExternalForm(string url, int id)
        {
            var actionsHandler = actionHandlerFactory.GetApplyActionHandler(id);
            if (!actionsHandler.IsActionDoneRecently(Request))
            {
                await applicationsManager.RedirectApplicationFormAsync(id);
                actionsHandler.RegisterAction(Request, Response);
            }

            return Redirect(url);
        }

        private async Task<OfferContentDisplayViewModel> GetOfferContentDisplayViewModel(int offerId)
        {
            var offer = await offerManager.GetAsync(offerId);

            var viewModelFactory = new OfferContentDisplayViewModelFactory();
            return viewModelFactory.Create(offer);
        }

        private async Task TryIncreaseViewsCount(int offerId)
        {
            var offer = await offerManager.GetAsync(offerId);

            if (!IsIncreaseOfferViewsCount(offer))
            {
                return;
            }

            var actionsHandler = actionHandlerFactory.GetViewActionHandler(offer.Id);
            if (actionsHandler.IsActionDoneRecently(Request))
            {
                return;
            }

            offer.NumberOfViews += 1;
            await offersRepository.Update(offer);

            actionsHandler.RegisterAction(Request, Response);
        }

        private async Task TryFillApplicationForm(OfferContentViewModel content)
        {
            if (!IsUserRegistered())
            {
                return;
            }

            var applicationUpdateFactory = new OfferApplicationUpdateViewModelFactory(
                User, identityRepository, profileRepository);
            var update = await applicationUpdateFactory.CreateAsync();
            await TryFillResumeField(update);

            content.Update = update;
        }

        private async Task TryFillResumeField(OfferApplicationUpdateViewModel update)
        {
            string? resumeUrl = update.AttachedResume.ResumeUrl;
            BlobDescription metadata = await resumeStorage.GetMetadataAsync(resumeUrl);
            update.AttachedResume.FileName = metadata.Name;
            update.AttachedResume.FileSize = metadata.Size;
        }

        private bool IsIncreaseOfferViewsCount(JobOffer offer)
        {
            return !UserRolesUtils.IsUserOwner(User, offer) && 
                   !UserRolesUtils.IsUserAdmin(User);
        }

        private bool IsUserRegistered()
        {
            return UserSessionUtils.IsLoggedIn(User) && UserRolesUtils.IsUserEmployee(User);
        }

        private int? TryGetUserProfileId()
        {
            int? profileId = null;
            if (UserSessionUtils.IsLoggedIn(User))
            {
                profileId = UserSessionUtils.GetProfileId(User);
            }
            return profileId;
        }
    }
}
