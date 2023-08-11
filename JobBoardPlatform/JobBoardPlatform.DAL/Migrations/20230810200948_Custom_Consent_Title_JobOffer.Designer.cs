﻿// <auto-generated />
using System;
using JobBoardPlatform.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobBoardPlatform.DAL.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230810200948_Custom_Consent_Title_JobOffer")]
    partial class Custom_Consent_Title_JobOffer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.CompanyIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ProfileId");

                    b.ToTable("CompanyIdentities");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.CompanyProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CompanyWebsiteUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyName")
                        .IsUnique();

                    b.ToTable("CompanyProfiles");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOffer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyProfileId")
                        .HasColumnType("int");

                    b.Property<int>("ContactDetailsId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomConsentClause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomConsentClauseTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InformationClause")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("bit");

                    b.Property<bool>("IsShelved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSuspended")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainTechnologyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfApplications")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfViews")
                        .HasColumnType("int");

                    b.Property<string>("ProcessingDataInFutureClause")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PublishedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkLocationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProfileId");

                    b.HasIndex("ContactDetailsId");

                    b.HasIndex("MainTechnologyTypeId");

                    b.HasIndex("WorkLocationId");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ApplicationFlagTypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeProfileId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<string>("ResumeUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationFlagTypeId");

                    b.HasIndex("EmployeeProfileId");

                    b.HasIndex("JobOfferId");

                    b.ToTable("OfferApplications");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferContactDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ContactTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContactTypeId");

                    b.ToTable("JobOfferContactDetails");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferEmploymentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmploymentTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<int?>("SalaryRangeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentTypeId");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("SalaryRangeId");

                    b.ToTable("JobOfferEmploymentDetails");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferSalariesRange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("From")
                        .HasColumnType("int");

                    b.Property<int>("SalaryCurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("To")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SalaryCurrencyId");

                    b.ToTable("JobOfferSalariesRange");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferTechKeyword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobOfferId");

                    b.ToTable("JobOfferTechKeywords");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.TechKeyword", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TechKeywords");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Employee.EmployeeIdentity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("ProfileId");

                    b.ToTable("EmployeeIdentities");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Employee.EmployeeProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedInUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResumeUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearsOfExperience")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmployeeProfiles");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.EnumTables.ApplicationFlagType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationFlagTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Type = "MustHire"
                        },
                        new
                        {
                            Id = 3,
                            Type = "AverageHire"
                        },
                        new
                        {
                            Id = 4,
                            Type = "RejectHire"
                        });
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.EnumTables.ContactType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Mail"
                        },
                        new
                        {
                            Id = 2,
                            Type = "ExternalForm"
                        },
                        new
                        {
                            Id = 3,
                            Type = "PrivateApplications"
                        });
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.EnumTables.CurrencyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CurrencyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "PLN"
                        },
                        new
                        {
                            Id = 2,
                            Type = "EUR"
                        });
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.EnumTables.JobOfferEmploymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EmploymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Permanent"
                        },
                        new
                        {
                            Id = 2,
                            Type = "B2B"
                        },
                        new
                        {
                            Id = 3,
                            Type = "MandateContract"
                        });
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.EnumTables.MainTechnologyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MainTechnologyTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Programming"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Audio"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Graphics3D"
                        },
                        new
                        {
                            Id = 4,
                            Type = "LevelDesign"
                        });
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.EnumTables.WorkLocationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkLocationsTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "OnSite"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Hybrid"
                        },
                        new
                        {
                            Id = 3,
                            Type = "FullyRemote"
                        });
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.CompanyIdentity", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.Company.CompanyProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOffer", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.Company.CompanyProfile", "CompanyProfile")
                        .WithMany()
                        .HasForeignKey("CompanyProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardPlatform.DAL.Models.Company.JobOfferContactDetails", "ContactDetails")
                        .WithMany()
                        .HasForeignKey("ContactDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardPlatform.DAL.Models.EnumTables.MainTechnologyType", "MainTechnologyType")
                        .WithMany()
                        .HasForeignKey("MainTechnologyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardPlatform.DAL.Models.EnumTables.WorkLocationType", "WorkLocation")
                        .WithMany()
                        .HasForeignKey("WorkLocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyProfile");

                    b.Navigation("ContactDetails");

                    b.Navigation("MainTechnologyType");

                    b.Navigation("WorkLocation");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferApplication", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.EnumTables.ApplicationFlagType", "ApplicationFlagType")
                        .WithMany()
                        .HasForeignKey("ApplicationFlagTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardPlatform.DAL.Models.Employee.EmployeeProfile", "EmployeeProfile")
                        .WithMany()
                        .HasForeignKey("EmployeeProfileId");

                    b.HasOne("JobBoardPlatform.DAL.Models.Company.JobOffer", "JobOffer")
                        .WithMany("OfferApplications")
                        .HasForeignKey("JobOfferId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationFlagType");

                    b.Navigation("EmployeeProfile");

                    b.Navigation("JobOffer");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferContactDetails", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.EnumTables.ContactType", "ContactType")
                        .WithMany()
                        .HasForeignKey("ContactTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ContactType");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferEmploymentDetails", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.EnumTables.JobOfferEmploymentType", "EmploymentType")
                        .WithMany()
                        .HasForeignKey("EmploymentTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardPlatform.DAL.Models.Company.JobOffer", null)
                        .WithMany("EmploymentDetails")
                        .HasForeignKey("JobOfferId");

                    b.HasOne("JobBoardPlatform.DAL.Models.Company.JobOfferSalariesRange", "SalaryRange")
                        .WithMany()
                        .HasForeignKey("SalaryRangeId");

                    b.Navigation("EmploymentType");

                    b.Navigation("SalaryRange");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferSalariesRange", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.EnumTables.CurrencyType", "SalaryCurrency")
                        .WithMany()
                        .HasForeignKey("SalaryCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SalaryCurrency");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferTechKeyword", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.Company.JobOffer", null)
                        .WithMany("TechKeywords")
                        .HasForeignKey("JobOfferId");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Employee.EmployeeIdentity", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.Employee.EmployeeProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOffer", b =>
                {
                    b.Navigation("EmploymentDetails");

                    b.Navigation("OfferApplications");

                    b.Navigation("TechKeywords");
                });
#pragma warning restore 612, 618
        }
    }
}
