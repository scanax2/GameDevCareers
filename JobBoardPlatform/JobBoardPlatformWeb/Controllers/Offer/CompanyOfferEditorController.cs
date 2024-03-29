﻿using FluentValidation;
using JobBoardPlatform.BLL.DTOs;
using JobBoardPlatform.BLL.Commands.Offer;
using JobBoardPlatform.BLL.Query.Identity;
using JobBoardPlatform.BLL.Services.Authentification.Authorization;
using JobBoardPlatform.DAL.Models.Enums;
using JobBoardPlatform.PL.Aspects.DataValidators;
using JobBoardPlatform.PL.ViewModels.Factories.Offer;
using JobBoardPlatform.PL.ViewModels.Factories.Offer.Company;
using JobBoardPlatform.PL.ViewModels.Models.Offer.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardPlatform.PL.Controllers.Offer
{
    [Route("offer")]
    [Authorize(Policy = AuthorizationPolicies.CompanyOnlyPolicy)]
    public class CompanyOfferEditorController : Controller
    {
        public const string EditorViewName = "Editor";

        public const string NextActionTempData = "NextAction";
        public const string NextControllerTempData = "NextController";
        public const string OfferIdTempData = "OfferId";

        private readonly IOfferManager offersManager;
        private readonly IOfferPlanQueryExecutor offerPlansQuery;
        private readonly IValidator<OfferData> validator;


        public CompanyOfferEditorController(
            IOfferManager offersManager, 
            IOfferPlanQueryExecutor offerPlansQuery,
            IValidator<OfferData> validator)
        {
            this.offersManager = offersManager;
            this.offerPlansQuery = offerPlansQuery;
            this.validator = validator;
        }

        [Route("new", Order = 1)]
        public async Task<IActionResult> AddNew()
        {
            var factory = new EditOfferViewModelFactory(offerPlansQuery);
            var viewModel = await factory.CreateAsync();

            return View(EditorViewName, viewModel);
        }

        [Route("new/{planType}", Order = 0)]
        public async Task<IActionResult> AddNew(string planType)
        {
            var factory = new EditOfferViewModelFactory(offerPlansQuery);
            var viewModel = await factory.CreateAsync();
            int planId = GetPlanTypeId(planType);
            viewModel.OfferDetails.PlanId = planId;

            return View(EditorViewName, viewModel);
        }

        [HttpPost("new", Order = 1)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNew(EditOfferViewModel viewModel)
        {
            return await TryAddNewOfferAsync(viewModel);
        }

        [HttpPost("new/{planType}", Order = 0)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNew(EditOfferViewModel viewModel, string planType)
        {
            return await TryAddNewOfferAsync(viewModel);
        }

        public IActionResult ReloadFormOnPlanChange(string planType, string? offerId = null, string? formDataTokenId = null)
        {
            if (!string.IsNullOrEmpty(offerId))
            {
                int offerIdInt = int.Parse(offerId);
                return RedirectToAction(
                    nameof(Edit),
                    new { offerId = offerId, planType = planType });
            }
            else
            {
                return RedirectToAction(
                    nameof(AddNew),
                    new { planType = planType });
            }
        }

        [Route("edit-{offerId}", Order = 0)]
        [Authorize(Policy = AuthorizationPolicies.OfferOwnerOnlyPolicy)]
        public async Task<IActionResult> Edit(int offerId, string? planType = null)
        {
            var factory = new EditOfferViewModelFactory(offerPlansQuery);
            var viewModel = await factory.CreateAsync();
            viewModel.OfferDetails = await GetOfferDetailsViewModelAsync(offerId);
            viewModel.Display.IsPaid = await IsOfferPaidAsync(offerId);

            if (!string.IsNullOrEmpty(planType))
            {
                int planId = GetPlanTypeId(planType);
                viewModel.OfferDetails.PlanId = planId;
            }

            return View(EditorViewName, viewModel);
        }

        [HttpPost("edit-{offerId}", Order = 0)]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = AuthorizationPolicies.OfferOwnerOnlyPolicy)]
        public async Task<IActionResult> Edit(int offerId, EditOfferViewModel viewModel)
        {
            viewModel.OfferDetails.OfferId = offerId;
            return await TryUpdateOfferAsync(viewModel);
        }

        private async Task<OfferDataViewModel> GetOfferDetailsViewModelAsync(int offerId)
        {
            var offer = await offersManager.GetAsync(offerId);
            var viewModelFactory = new OfferDetailsViewModelFactory();
            return viewModelFactory.Create(offer);
        }

        private async Task<bool> IsOfferPaidAsync(int offerId)
        {
            var offer = await offersManager.GetAsync(offerId);
            return offer.IsPaid;
        }

        private async Task<IActionResult> TryAddNewOfferAsync(EditOfferViewModel viewModel)
        {
            var result = await validator.ValidateAsync(viewModel.OfferDetails);
            if (result.IsValid)
            {
                int profileId = UserSessionUtils.GetProfileId(User);
                await offersManager.AddAsync(profileId, viewModel.OfferDetails);
                return RedirectOnSuccess();
            }
            else
            {
                result.AddToModelState(this.ModelState, nameof(viewModel.OfferDetails));
            }

            await SetPricingPlans(viewModel);
            return View(EditorViewName, viewModel);
        }

        private async Task<IActionResult> TryUpdateOfferAsync(EditOfferViewModel viewModel)
        {
            var result = await validator.ValidateAsync(viewModel.OfferDetails);
            if (result.IsValid)
            {
                await offersManager.UpdateAsync(viewModel.OfferDetails);
                return RedirectOnSuccess();
            }
            else
            {
                result.AddToModelState(this.ModelState, nameof(viewModel.OfferDetails));
            }

            await SetPricingPlans(viewModel);
            return View(EditorViewName, viewModel);
        }

        private IActionResult RedirectOnSuccess()
        {
            return RedirectToAction("Offers", "CompanyOffersPanel");
        }

        private int GetPlanTypeId(string plan)
        {
            var plans = Enum.GetValues(typeof(JobOfferPlanEnum))
                .Cast<JobOfferPlanEnum>().ToList();

            if (plan == "new")
            {
                plan = plans[1].ToString().ToLower();
            }

            for (int i = 0; i < plans.Count; i++)
            {
                if (plan.ToLower() == plans[i].ToString().ToLower())
                {
                    return i + 1;
                }
            }
            return 2;
        }

        private async Task SetPricingPlans(EditOfferViewModel viewModel)
        {
            var factory = new EditOfferViewModelFactory(offerPlansQuery);
            var editViewModel = await factory.CreateAsync();
            viewModel.PricingPlans = editViewModel.PricingPlans;
        }
    }
}
