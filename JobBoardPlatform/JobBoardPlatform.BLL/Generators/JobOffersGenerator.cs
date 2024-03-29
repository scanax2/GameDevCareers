﻿using JobBoardPlatform.BLL.DTOs;
using JobBoardPlatform.BLL.Generators;
using JobBoardPlatform.DAL.Models.Company;
using JobBoardPlatform.DAL.Models.Enums;

namespace JobBoardPlatform.BLL.Utils
{
    /// <summary>
    /// For tests only
    /// </summary>
    internal class JobOffersGenerator
    {
        private readonly string[] TitleSeniority = new string[] { "Trainee", "Junior", "Middle", "Senior", "Regular", "Lead" };
        private readonly string[] TitleGameplayPrefixTechnology = new string[] { "Unity", "Unreal Engine", "C#", "Rust", "C++", "Python Machine Learning" };
        private readonly string[] TitleGameplayPostfix = new string[] { "Developer", "Gameplay Programmer", "AI Programmer", "Programmer", "Engineer" };
        private readonly string[] TitleArtAndAnimation = new string[] { "3D Art", "3D Animator", "Animator" };
        private readonly string[] TitleDesign = new string[] { "Level Designer", "Quest Designer", "Game Designer", "Writer" };
        private readonly string[] TitleAudio = new string[] { "Audio", "Sound Designer" };
        private readonly string[] TitleTesting = new string[] { "QA Tester", "Game Tester", "QA Analyst" };
        private readonly string[] TitleManagement = new string[] { "PR & Marketing", "Producer", "Co-Founder", "Game Producer", "Technical Producer", "Associate Producer", "Executive Producer" };
        private readonly string[] TitleOther = new string[] { "Narrative Designer", "Creative Copywriter", "Community Manager", "Narrative Designer", "Data Specialist", "Translator" };

        private readonly string[] Countries = new string[] { "Poland", "United States", "United Kingdom", "France", "Germany" };
        private readonly string[] Cities = new string[] { "Warsaw", "New York", "London", "Paris", "Berlin" };
        private readonly string[] Addresses = new string[] { "3545 Lochmere Lane", "344 Pratt Avenue", "ul. Podskarbińska 89" };
        private readonly string Description = "\r\n  <p>Hey everyone!</p>\r\n\r\n\r\n\r\n<p>We are looking for Programmer to join our team.</p>\r\n\r\n<h3>Requirements:</h3>\r\n\r\n<ul>\r\n<li>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ut ullamcorper orci.</li>\r\n<li>Nunc tempus arcu vitae commodo consequat. Maecenas sodales, velit a tincidunt aliquam, sapien dui tempus metus, in suscipit tortor massa in turpis. Proin ornare dolor odio, ut iaculis mauris porttitor sit amet.</li>\r\n<li>Etiam consequat enim vel augue lobortis fermentum.</li><li>Phasellus placerat sit amet mi in dictum.</li>\r\n\r\n</ul>\r\n\r\n<h3>Responsibilities:</h3>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n<ul>\r\n<li>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ut ullamcorper orci.</li>\r\n<li>Nunc tempus arcu vitae commodo consequat. Maecenas sodales, velit a tincidunt aliquam, sapien dui tempus metus, in suscipit tortor massa in turpis. Proin ornare dolor odio, ut iaculis mauris porttitor sit amet.</li>\r\n<li>Etiam consequat enim vel augue lobortis fermentum.</li><li>Phasellus placerat sit amet mi in dictum.</li>\r\n\r\n</ul>\r\n\r\n\r\n\r\n\r\n\r\n<h3>Pluses:</h3>\r\n\r\n\r\n\r\n<ul>\r\n<li>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ut ullamcorper orci.</li>\r\n<li>Nunc tempus arcu vitae commodo consequat. Maecenas sodales, velit a tincidunt aliquam, sapien dui tempus metus, in suscipit tortor massa in turpis. Proin ornare dolor odio, ut iaculis mauris porttitor sit amet.</li>\r\n<li>Etiam consequat enim vel augue lobortis fermentum.</li><li>Phasellus placerat sit amet mi in dictum.</li>\r\n\r\n</ul><h3>What are we offering?</h3>\r\n\r\n\r\n\r\n<ul>\r\n<li>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris ut ullamcorper orci.</li>\r\n<li>Nunc tempus arcu vitae commodo consequat. Maecenas sodales, velit a tincidunt aliquam, sapien dui tempus metus, in suscipit tortor massa in turpis. Proin ornare dolor odio, ut iaculis mauris porttitor sit amet.</li>\r\n<li>Etiam consequat enim vel augue lobortis fermentum.</li><li>Phasellus placerat sit amet mi in dictum.</li>\r\n\r\n</ul><p>Cheers!</p> <hr>";
        private readonly int[] SalaryRanges = new int[] { 4500, 7000, 13000, 25000, 30000, 40000 };
        private readonly string ExternalLink = "http://www.example.com/index.html";
        private readonly string InformationClause = "Nullam nec posuere quam. Nullam id elementum risus, non lacinia lacus. Vestibulum auctor tortor et nunc sollicitudin rhoncus. Aenean faucibus orci sit amet nulla aliquam, sit amet gravida ipsum sodales. Morbi ullamcorper lacus sed posuere fringilla. Nam sit amet orci molestie, fermentum dolor sit amet, hendrerit elit.";
        private readonly string FutureDataProcessing = "Aliquam sit amet mi vel metus lacinia ultricies eget a purus. Integer semper porttitor libero, id accumsan neque mollis ut. Aenean malesuada velit at risus hendrerit, vel lobortis felis commodo. Nullam sollicitudin nisl quis magna viverra tempor. Nulla ut nisi accumsan, facilisis ipsum volutpat, accumsan purus. Mauris pulvinar ipsum ex, eget eleifend nunc molestie at.";
        private readonly string CustomConsentTitle = "Custom consent title";
        private readonly string CustomConsentContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam id purus finibus, mattis est non, mollis velit. Cras vulputate urna sit amet fringilla rutrum. Mauris venenatis sagittis tincidunt. Fusce vel velit molestie, faucibus nunc eget, lobortis justo. Ut lobortis accumsan aliquam. Sed lobortis dictum fringilla. Donec sollicitudin tellus a sem accumsan bibendum. Mauris fermentum, nibh ut rhoncus elementum, mi velit commodo tortor, tempor placerat neque nisi quis sapien.";


        public OfferData GenerateData(CompanyIdentity companyIdentity)
        {
            var random = new Random();

            var mainTechnology = GetRandomTechnology(random);
            var address = GetAddress(random);
            string? seniority = GetSeniority(random);
            var details = GetEmploymentDetails(seniority, random)!;
            var contact = GetContactType(companyIdentity, random);
            string title = GetTitle(mainTechnology, random, seniority);
            string[] techKeywords = title.Split();
            var workLocationType = GetWorkLocation(random);
            string? futureDataProcessing = GetFutureProcessingConsent(random);
            (string? customConsent, string? customConsentTitle) = GetCustomConsent(random);

            var newOfferData = new MockOfferData()
            {
                MainTechnologyType = (int)mainTechnology + 1,
                PlanId = GetPlanId(random),
                Country = address.Item1,
                City = address.Item2,
                Street = address.Item3,
                EmploymentTypes = details,
                ApplicationsContactType = (int)contact.Item1 + 1,
                ApplicationsContactEmail = contact.Item2,
                JobDescription = Description,
                JobTitle = title,
                TechKeywords = techKeywords,
                WorkLocationType = (int)workLocationType + 1,
                InformationClause = InformationClause,
                ApplicationsContactExternalFormUrl = contact.Item2,
                IsDisplayConsentForFutureRecruitment = !string.IsNullOrEmpty(futureDataProcessing),
                ConsentForFutureRecruitmentContent = futureDataProcessing,
                IsDisplayCustomConsent = !string.IsNullOrEmpty(customConsent),
                CustomConsentContent = customConsent,
                CustomConsentTitle = customConsentTitle
            };

            return newOfferData;
        }

        private MainTechnologyTypeEnum GetRandomTechnology(Random random)
        {
            var mainTechnology = MainTechnologyTypeEnum.Programming;

            if (random.NextDouble() < 0.5)
            {
                mainTechnology = MainTechnologyTypeEnum.Programming;
            }
            else
            {
                var technologies = Enum.GetValues(typeof(MainTechnologyTypeEnum))
                    .Cast<MainTechnologyTypeEnum>()
                    .ToList();
                int selected = random.Next(technologies.Count);
                mainTechnology = technologies[selected];
            }

            return mainTechnology;
        }

        private (string, string, string?) GetAddress(Random random)
        {
            int randomAddress = random.Next(Countries.Length);
            string country = Countries[randomAddress];
            string city = Cities[randomAddress];

            string? address = null;

            if (random.NextDouble() < 0.75)
            {
                address = null;
            }
            else
            {
                randomAddress = random.Next(Addresses.Length);
                address = Addresses[randomAddress];
            }

            return (country, city, address);
        }

        private string? GetSeniority(Random random)
        {
            string? seniority = null;
            if (random.NextDouble() < 0.75)
            {
                int randomIndex = random.Next(TitleSeniority.Length);
                seniority = TitleSeniority[randomIndex];
            }
            return seniority;
        }

        private EmploymentType[] GetEmploymentDetails(string? seniority, Random random)
        {
            var employmentTypes = Enum.GetValues(typeof(EmploymentTypeEnum))
                .Cast<EmploymentTypeEnum>()
                .ToList();

            int employmentTypesCount = random.Next(1, 4);
            var details = new List<EmploymentType>(employmentTypesCount);

            bool isNotDiscloseSalary = false;
            if (random.NextDouble() < 0.5f)
            {
                isNotDiscloseSalary = true;
            }

            for (int i = 0; i < employmentTypesCount; i++)
            {
                // setup salary range
                int fromIndex = 0;
                if (string.IsNullOrEmpty(seniority))
                {
                    fromIndex = random.Next(SalaryRanges.Length);
                }
                else
                {
                    fromIndex = Array.IndexOf(TitleSeniority, seniority);
                }

                int? fromSalary = SalaryRanges[fromIndex];
                int? toSalary = fromSalary + random.Next(10, 20) * 1_000;

                // select employment type & modify salary range
                var notIncludedTypes = employmentTypes.Where(x => details.All(y => (int)x + 1 != y.TypeId))
                    .ToArray();
                int randomTypeIndex = random.Next(notIncludedTypes.Length);
                var employmentType = notIncludedTypes[randomTypeIndex];

                if (employmentType == EmploymentTypeEnum.B2B)
                {
                    fromSalary = (int)(fromSalary * 1.5f);
                    toSalary = (int)(toSalary * 1.5f);
                }

                // select currency & modify salary range
                var currency = CurrencyTypeEnum.PLN;

                if (random.NextDouble() < 0.5)
                {
                    currency = CurrencyTypeEnum.EUR;
                    fromSalary = (int)(fromSalary * 0.22f * 1.35f);
                    toSalary = (int)(toSalary * 0.22f * 1.35f);
                }

                if (isNotDiscloseSalary)
                {
                    fromSalary = null;
                    toSalary = null;
                }

                details.Add(new EmploymentType()
                {
                    SalaryFromRange = fromSalary,
                    SalaryToRange = toSalary,
                    TypeId = (int)employmentType + 1,
                    SalaryCurrencyType = (int)currency + 1
                });
            }

            return details.ToArray();
        }

        private (ContactTypeEnum, string?) GetContactType(CompanyIdentity company, Random random)
        {
            ContactTypeEnum contactType = ContactTypeEnum.PrivateApplications;
            string? contactAddress = null;

            if (random.NextDouble() < 0.45f)
            {
                contactType = ContactTypeEnum.Mail;
                contactAddress = company.Email;
            }
            else if (random.NextDouble() < 0.7f)
            {
                contactType = ContactTypeEnum.ExternalForm;
                contactAddress = ExternalLink;
            }

            return (contactType, contactAddress);
        }

        private string GetTitle(MainTechnologyTypeEnum mainTechnology, Random random, string? seniority)
        {
            if (seniority == null)
            {
                seniority = string.Empty;
            }

            string postfix = string.Empty;
            if (mainTechnology == MainTechnologyTypeEnum.Programming)
            {
                int randomIndex = random.Next(TitleGameplayPrefixTechnology.Length);
                string prefixTech = TitleGameplayPrefixTechnology[randomIndex];

                randomIndex = random.Next(TitleGameplayPostfix.Length);
                string postfixTech = TitleGameplayPostfix[randomIndex];
                postfix = $"{prefixTech} {postfixTech}";
            }
            else if (mainTechnology == MainTechnologyTypeEnum.Audio)
            {
                int randomIndex = random.Next(TitleAudio.Length);
                string prefixTech = TitleAudio[randomIndex];
                postfix = prefixTech;
            }
            else if (mainTechnology == MainTechnologyTypeEnum.Graphics3D)
            {
                int randomIndex = random.Next(TitleArtAndAnimation.Length);
                string prefixTech = TitleArtAndAnimation[randomIndex];
                postfix = prefixTech;
            }
            else if (mainTechnology == MainTechnologyTypeEnum.LevelDesign)
            {
                int randomIndex = random.Next(TitleDesign.Length);
                string prefixTech = TitleDesign[randomIndex];
                postfix = prefixTech;
            }
            else if (mainTechnology == MainTechnologyTypeEnum.Testing)
            {
                int randomIndex = random.Next(TitleTesting.Length);
                string prefixTech = TitleTesting[randomIndex];
                postfix = prefixTech;
            }
            else if (mainTechnology == MainTechnologyTypeEnum.Management)
            {
                int randomIndex = random.Next(TitleManagement.Length);
                string prefixTech = TitleManagement[randomIndex];
                postfix = prefixTech;
            }
            else if (mainTechnology == MainTechnologyTypeEnum.Other)
            {
                int randomIndex = random.Next(TitleOther.Length);
                string prefixTech = TitleOther[randomIndex];
                postfix = prefixTech;
            }

            string title = $"{seniority} {postfix}";

            return title;
        }

        private WorkLocationTypeEnum GetWorkLocation(Random random)
        {
            var workLocationTypes = Enum.GetValues(typeof(WorkLocationTypeEnum))
                .Cast<WorkLocationTypeEnum>()
                .ToList();

            int randomIndex = random.Next(workLocationTypes.Count);
            return workLocationTypes[randomIndex];
        }

        private string? GetFutureProcessingConsent(Random random)
        {
            if (random.NextDouble() < 0.5f)
            {
                return FutureDataProcessing;
            }
            else
            {
                return null;
            }
        }

        private (string?, string?) GetCustomConsent(Random random)
        {
            if (random.NextDouble() < 0.5f)
            {
                return (CustomConsentContent, CustomConsentTitle);
            }
            else
            {
                return (null, null);
            }
        }

        private int GetPlanId(Random random)
        {
            var planTypes = Enum.GetValues(typeof(JobOfferPlanEnum))
                .Cast<JobOfferPlanEnum>()
                .ToList();

            int randomPlanId = random.Next(planTypes.Count) + 1;
            return randomPlanId;
        }
    }
}
