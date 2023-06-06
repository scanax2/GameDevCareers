﻿using JobBoardPlatform.BLL.Commands.Admin;
using JobBoardPlatform.BLL.Commands.Offer;
using JobBoardPlatform.BLL.Query.Identity;
using JobBoardPlatform.BLL.Search.CompanyPanel.Offers;
using JobBoardPlatform.BLL.Services.Authorization.Utilities;
using JobBoardPlatform.DAL.Models.Company;
using JobBoardPlatform.PL.ViewModels.Contracts;
using JobBoardPlatform.PL.ViewModels.Factories.Offer.Company;
using JobBoardPlatform.PL.ViewModels.Models.Templates;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobBoardPlatform.PL.Controllers.Offer
{
    [Authorize(Policy = AuthorizationPolicies.CompanyOnlyPolicy)]
    public class CompanyOffersPanelController : OfferCardsControllerBase
    {
        private readonly CompanyOffersSearcher offersSearcher;
        private readonly OfferQueryExecutor queryExecutor;


        public CompanyOffersPanelController(CompanyOffersSearcher offersSearcher,
            OfferCommandsExecutor commandsExecutor,
            OfferQueryExecutor queryExecutor)
            : base(commandsExecutor)
        {
            this.offersSearcher = offersSearcher;
            this.queryExecutor = queryExecutor;
        }

        public async virtual Task<IActionResult> Offers()
        {
            var containerFactory = new CompanyOffersContainerViewModelFactory(
                offersSearcher, GetSearchParams());
            var container = await containerFactory.Create();

            return View(container);
        }

        protected override Task<CardsContainerViewModel> GetContainer()
        {
            var containerFactory = new CompanyOffersContainerViewModelFactory(
                offersSearcher, GetSearchParams());
            return containerFactory.Create();
        }

        private CompanyPanelOfferSearchParameters GetSearchParams()
        {
            var searchParamsFactory = new CompanyPanelOfferSearchParametersFactory();
            return searchParamsFactory.GetSearchParams(Request);
        }

        protected override Task<JobOffer> GetLoadedOffer(int offerId)
        {
            return queryExecutor.GetOfferById(offerId);
        }

        protected override IContainerCard GetContainerCard(JobOffer offer)
        {
            var cardFactory = new CompanyOfferViewModelFactory();
            return cardFactory.CreateCard(offer);
        }

        public async Task<IActionResult> RequestPayment(int offerId)
        {
            // TODO: payment logic
            /*var offer = await offersRepository.Get(offerId);
            offer.IsPaid = true;
            offer.IsPublished = true;
            offer.PublishedAt = DateTime.Now;

            await offersRepository.Update(offer);*/

            return Redirect("Offers");
        }

        public async virtual Task<IActionResult> ProcessPayment(string paymentId, string orderId, string signature)
        {
            string message = "SUCCESS";
            return Json(new { Message = message });
        }
    }
}
