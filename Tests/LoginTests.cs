using System.Text.RegularExpressions;
using Microsoft.Playwright.NUnit;
using PlaywrightNetEx.Pages;

namespace PlaywrightNetEx.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class LoginTests : BaseTest
    {
        private const string expectedTitle = "Swag Labs";
        private const string expectedUrl = "https://www.saucedemo.com/inventory.html";

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
            await Expect(Page).ToHaveTitleAsync(new Regex(expectedTitle));
        }

        [Test]
        public async Task LoginStandardUser()
        {
            await _loginPage.LoginStandardUser();
            await Expect(Page).ToHaveURLAsync(expectedUrl);
        }

        [Test]
        public async Task LoginLockedUser()
        {
            await _loginPage.LoginLockedUser();
            await Expect(_loginPage.BtnError).ToBeVisibleAsync();
        }
    }
}