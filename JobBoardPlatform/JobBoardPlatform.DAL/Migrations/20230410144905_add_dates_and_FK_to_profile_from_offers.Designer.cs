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
    [Migration("20230410144905_add_dates_and_FK_to_profile_from_offers")]
    partial class add_dates_and_FK_to_profile_from_offers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.Company.CompanyIdentity", b =>
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

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.Company.CompanyProfile", b =>
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

                    b.Property<int>("CompanyProfileId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Published")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkLocationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyProfileId");

                    b.ToTable("JobOffers");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferEmploymentDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmploymentTypesId")
                        .HasColumnType("int");

                    b.Property<int?>("JobOfferId")
                        .HasColumnType("int");

                    b.Property<int>("SalaryCurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("SalaryFromRangeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmploymentTypesId");

                    b.HasIndex("JobOfferId");

                    b.HasIndex("SalaryCurrencyId");

                    b.HasIndex("SalaryFromRangeId");

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

                    b.Property<int>("To")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("JobOfferSalariesRange");
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

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.EnumTables.EmploymentType", b =>
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
                            Type = "ContractOfEmployment"
                        },
                        new
                        {
                            Id = 2,
                            Type = "B2B"
                        },
                        new
                        {
                            Id = 3,
                            Type = "MandatoryContract"
                        });
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.Company.CompanyIdentity", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.Company.Company.CompanyProfile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOffer", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.Company.Company.CompanyProfile", "CompanyProfile")
                        .WithMany()
                        .HasForeignKey("CompanyProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyProfile");
                });

            modelBuilder.Entity("JobBoardPlatform.DAL.Models.Company.JobOfferEmploymentDetails", b =>
                {
                    b.HasOne("JobBoardPlatform.DAL.Models.EnumTables.EmploymentType", "EmploymentTypes")
                        .WithMany()
                        .HasForeignKey("EmploymentTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardPlatform.DAL.Models.Company.JobOffer", null)
                        .WithMany("JobOfferEmploymentDetails")
                        .HasForeignKey("JobOfferId");

                    b.HasOne("JobBoardPlatform.DAL.Models.EnumTables.CurrencyType", "SalaryCurrency")
                        .WithMany()
                        .HasForeignKey("SalaryCurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobBoardPlatform.DAL.Models.Company.JobOfferSalariesRange", "SalaryFromRange")
                        .WithMany()
                        .HasForeignKey("SalaryFromRangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmploymentTypes");

                    b.Navigation("SalaryCurrency");

                    b.Navigation("SalaryFromRange");
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
                    b.Navigation("JobOfferEmploymentDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
