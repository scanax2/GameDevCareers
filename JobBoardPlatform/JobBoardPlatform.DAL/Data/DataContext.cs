﻿using JobBoardPlatform.DAL.Data.Enums;
using JobBoardPlatform.DAL.Data.Setup;
using JobBoardPlatform.DAL.Models.Admin;
using JobBoardPlatform.DAL.Models.Company;
using JobBoardPlatform.DAL.Models.Employee;
using JobBoardPlatform.DAL.Models.Enums;
using JobBoardPlatform.DAL.Models.EnumTables;
using Microsoft.EntityFrameworkCore;

namespace JobBoardPlatform.DAL.Data
{
    public class DataContext : DbContext
    {
        // Employee
        public DbSet<EmployeeIdentity> EmployeeCredentials { get; set; }
        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }

        // Company
        public DbSet<CompanyIdentity> CompanyCredentials { get; set; }
        public DbSet<CompanyProfile> CompanyProfiles { get; set; }

        public DbSet<JobOffer> JobOffers { get; set; }
        public DbSet<JobOfferCategoryType> JobOfferCategories { get; set; }
        public DbSet<JobOfferPlan> JobOfferPlans { get; set; }
        public DbSet<JobOfferEmploymentDetails> JobOfferEmploymentDetails { get; set; }
        public DbSet<JobOfferSalariesRange> JobOfferSalariesRange { get; set; }
        public DbSet<JobOfferEmploymentType> EmploymentTypes { get; set; }
        public DbSet<JobOfferContactDetails> ContactDetails { get; set; }
        public DbSet<JobOfferApplication> OfferApplications { get; set; }
        public DbSet<JobOfferTechKeyword> JobOfferTechKeywords { get; set; }

        // Common
        public DbSet<AdminIdentity> AdminCredentials { get; set; }
        public DbSet<CurrencyType> CurrencyTypes { get; set; }
        public DbSet<TechKeyword> TechKeywords { get; set; }
        public DbSet<WorkLocationType> WorkLocationTypes { get; set; }
        public DbSet<MainTechnologyType> MainFieldTypes { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<ApplicationFlagType> ApplicationFlagTypes { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateEnumEntities(modelBuilder);
            CreateOfferPlans(modelBuilder);
        }

        private void CreateEnumEntities(ModelBuilder modelBuilder)
        {
            var enumCreator = new EnumModelCreator(modelBuilder);
            enumCreator.SetDataForEntity<JobOfferEmploymentType, EmploymentTypeEnum>();
            enumCreator.SetDataForEntity<CurrencyType, CurrencyTypeEnum>();
            enumCreator.SetDataForEntity<WorkLocationType, WorkLocationTypeEnum>();
            enumCreator.SetDataForEntity<MainTechnologyType, MainTechnologyTypeEnum>();
            enumCreator.SetDataForEntity<ContactType, ContactTypeEnum>();
            enumCreator.SetDataForEntity<ApplicationFlagType, ApplicationFlagEnum>();
            enumCreator.SetDataForEntity<JobOfferCategoryType, JobOfferCategoryEnum>();
            enumCreator.SetDataForEntity<JobOfferPlanType, JobOfferPlanEnum>();
        }

        private void CreateOfferPlans(ModelBuilder modelBuilder)
        {
            var planCreator = new JobOfferPlanCreator(modelBuilder);
            planCreator.CreateRecords();
        }
    }
}
