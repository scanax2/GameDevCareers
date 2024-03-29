using JobBoardPlatform.IntegrationTests.Common.Assertions;
using JobBoardPlatform.IntegrationTests.Common.Fixtures;
using JobBoardPlatform.IntegrationTests.Common.Utils;

namespace JobBoardPlatform.IntegrationTests.Applications
{
    public class ApplyToOfferTest : IClassFixture<AppFixture>, IDisposable
    {
        private readonly AppFixture fixture;
        private readonly EmployeeIntegrationTestsUtils testsUtils;
        private readonly EmployeeProfileAssert assert;


        public ApplyToOfferTest(AppFixture fixture)
        {
            this.fixture = fixture;
            this.testsUtils = new EmployeeIntegrationTestsUtils(fixture.ServiceProvider);
            this.assert = new EmployeeProfileAssert(testsUtils);
        }

        [Fact]
        public async Task Test()
        {
            string userEmail = testsUtils.GetUserExampleEmail();
            await testsUtils.AddExampleEmployeeAsync(userEmail);

            await testsUtils.ApplyToOffer(userEmail, 0);
        }

        public void Dispose()
        {
            fixture.Dispose();
        }
    }
}