﻿using JobBoardPlatform.PL.ViewModels.Contracts;

namespace JobBoardPlatform.PL.ViewModels.Models.Admin
{
    public class AdminCompanyCardViewModel : IContainerCard
    {
        public string PartialView => "./Admin/_CompanyCardAdminView";
        public int Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProfileImageUrl { get; set; } = string.Empty;
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? CompanyWebsiteUrl { get; set; }
    }
}
