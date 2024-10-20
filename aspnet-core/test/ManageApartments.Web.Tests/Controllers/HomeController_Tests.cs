using System.Threading.Tasks;
using ManageApartments.Models.TokenAuth;
using ManageApartments.Web.Controllers;
using Shouldly;
using Xunit;

namespace ManageApartments.Web.Tests.Controllers
{
    public class HomeController_Tests: ManageApartmentsWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}