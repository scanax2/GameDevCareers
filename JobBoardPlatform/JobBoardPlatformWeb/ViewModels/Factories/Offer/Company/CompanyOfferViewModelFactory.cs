﻿using JobBoardPlatform.BLL.Common.Formatter;
using JobBoardPlatform.BLL.Services.Background;
using JobBoardPlatform.BLL.Services.Offer.State;
using JobBoardPlatform.DAL.Models.Company;
using JobBoardPlatform.PL.ViewModels.Contracts;
using JobBoardPlatform.PL.ViewModels.Factories.Templates;
using JobBoardPlatform.PL.ViewModels.Models.Offer.Company;

namespace JobBoardPlatform.PL.ViewModels.Factories.Offer.Company
{
    public class CompanyOfferViewModelFactory : IContainerCardFactory<JobOffer>
    {
        public IContainerCard CreateCard(JobOffer offer)
        {
            var offerCard = new CompanyOfferCardViewModel();

            var offerState = new OfferState(offer);
            offerCard.IsVisibleOnMainPage = offerState.IsVisibleOnMainPage();
            offerCard.IsAvailableForEdit = offerState.IsAvailableForEdit();
            offerCard.StateType = offerState.GetState();

            Map(offer, offerCard);
            MapCardDisplay(offer, offerCard);

            return offerCard;
        }

        private void Map(JobOffer from, CompanyOfferCardViewModel to)
        {
            to.TotalViews = from.NumberOfViews;
            to.TotalApplicants = from.NumberOfApplications;
            to.MainTechnology = from.MainTechnologyType.Type;
            to.ContactType = from.ContactDetails.ContactType.Type;
            to.ContactAddress = from.ContactDetails.ContactAddress;

            to.IsPaid = from.IsPaid;
            to.IsPublished = from.IsPublished;
            to.IsShelved = from.IsShelved;
            to.IsDeleted = from.IsDeleted;
            to.DaysLeft = GetDaysLeft(from);
        }

        private string GetDaysLeft(JobOffer offer)
        {
            var daysLeftService = new OfferExpirationService(offer);
            int daysLeft = daysLeftService.GetDaysLeft();

            var daysLeftFormatter = new DaysLeftFormatter();
            return daysLeftFormatter.GetString(daysLeft);
        }

        private void MapCardDisplay(JobOffer from, CompanyOfferCardViewModel to)
        {
            var offerCardFactory = new OfferCardViewModelFactory();
            var offerCardViewModel = offerCardFactory.CreateCard(from);

            to.CardDisplay = offerCardViewModel;
        }
    }
}
