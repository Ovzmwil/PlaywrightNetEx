using System.Text.RegularExpressions;
using Microsoft.Playwright.NUnit;
using PlaywrightNetEx.Pages;

namespace PlaywrightNetEx.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class LoginTests : PageTest
    {
        private LoginPage _loginPage;

        [SetUp]
        public async Task SetUp()
        {
            _loginPage = new LoginPage(Page);
            await _loginPage.GoToLoginPage();
        }

        [Test]
        public async Task EnterLoginPage()
        {
            await Expect(Page).ToHaveTitleAsync(new Regex("Swag Labs"));
        }

        [Test]
        public async Task LoginStandardUser()
        {
            await _loginPage.LoginStandardUser();
            await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
        }

        [Test]
        public async Task LoginLockedUser()
        {
            await _loginPage.LoginLockedUser();
            await Expect(_loginPage.ErrorButton).ToBeVisibleAsync();
        }
    }
}