﻿using JobBoardPlatform.DAL.Contexts;
using JobBoardPlatform.DAL.Models.Company;

namespace JobBoardPlatform.BLL.Commands.Offer
{
    public class DeleteApplicationCommand : ICommand
    {
        private readonly int applicationId;
        private readonly OfferContext offerModel;


        public DeleteApplicationCommand(int applicationId, OfferContext offerModel)
        {
            this.applicationId = applicationId;
            this.offerModel = offerModel;
        }

        public async Task Execute()
        {
            var application = await offerModel.ApplicationsRepository.Get(applicationId);
            await UnassignResumesFromOffer(application);
            await offerModel.ApplicationsRepository.Delete(applicationId);
        }

        private async Task UnassignResumesFromOffer(JobOfferApplication application)
        {
            int offerId = application.JobOfferId;

            await offerModel.ProfileResumeStorage.UnassignFromOfferOnOfferClosedAsync(
                offerId, application.ResumeUrl);
            await offerModel.ApplicationsResumeStorage.UnassignFromOfferOnOfferClosedAsync(
                offerId, application.ResumeUrl);
        }
    }
}
