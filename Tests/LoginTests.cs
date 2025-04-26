using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using PlaywrightNetEx.Pages;

namespace PlaywrightNetEx.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class LoginTests : PageTest
    {
        private LoginPage loginPage;

        [SetUp]
        public async Task SetUp()
        {
            loginPage = new LoginPage(Page);
            await loginPage.GoToLoginPage();
        }

        [Test]
        public async Task EnterLoginPage()
        {
            await Expect(Page).ToHaveTitleAsync(new Regex("Swag Labs"));
        }

        [Test]
        public async Task LoginStandardUser()
        {
            await loginPage.LoginStandardUser();
            await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
        }

        [Test]
        public async Task LoginLockedUser()
        {
            await loginPage.LoginLockedUser();
            await Expect(loginPage.GetErrorElement()).ToBeVisibleAsync();
        }
    }
}