﻿using FluentValidation;
using JobBoardPlatform.BLL.Commands.Offer;
using JobBoardPlatform.DAL.Repositories.Blob.AttachedResume;
using JobBoardPlatform.PL.ViewModels.Models.Offer.Users;

namespace JobBoardPlatform.PL.Aspects.DataValidators.Offers
{
    public class OfferApplicationFormValidator : AbstractValidator<OfferApplicationUpdateViewModel>
    {
        public OfferApplicationFormValidator(IProfileResumeBlobStorage resumeStorage, IOfferManager offerManager)
        {
            AddRulesForConsent(offerManager);
            RuleFor(content => content.FullName).NotEmpty().WithMessage("Please enter your full name");
            RuleFor(content => content.Email).NotEmpty().EmailAddress().WithMessage("Please enter your email");
            RuleFor(content => content.AttachedResume).SetValidator(new ResumeValidator(resumeStorage));
        }

        private void AddRulesForConsent(IOfferManager offerManager)
        {
            WhenAsync(async (content, ct) => await IsCustomConsentClauseAsync(offerManager, content.OfferId), () =>
            {
                RuleFor(content => content.IsCustomConsent)
                    .Equal(true)
                    .WithMessage($"Please read and check consent");
            });
            WhenAsync(async (content, ct) => await IsFutureRecruitmentClauseAsync(offerManager, content.OfferId), () =>
            {
                RuleFor(content => content.IsProcessingDataInFutureConsent)
                    .Equal(true)
                    .WithMessage($"Please read and check consent");
            });
        }

        private async Task<bool> IsCustomConsentClauseAsync(IOfferManager offerManager, int offerId)
        {
            return !string.IsNullOrEmpty((await offerManager.GetAsync(offerId)).CustomConsentClauseTitle);
        }

        private async Task<bool> IsFutureRecruitmentClauseAsync(IOfferManager offerManager, int offerId)
        {
            return !string.IsNullOrEmpty((await offerManager.GetAsync(offerId)).ProcessingDataInFutureClause);
        }
    }
}
