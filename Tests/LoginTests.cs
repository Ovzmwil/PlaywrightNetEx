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

        [SetUp]
        public async Task SetUp()
        {
            await Page.SetViewportSizeAsync(1280, 720);
            await Page.GotoAsync("https://www.saucedemo.com");
        }

        [Test]
        public async Task EnterLoginPage()
        {
            await Expect(Page).ToHaveTitleAsync(new Regex("Swag Labs"));
        }

        [Test]
        public async Task LoginStandardUser()
        {
            await LoginPage.LoginStandardUser(Page);
            await Expect(Page).ToHaveURLAsync("https://www.saucedemo.com/inventory.html");
        }

        [Test]
        public async Task LoginLockedUser()
        {
            await LoginPage.LoginLockedUser(Page);
            await Expect(LoginPage.GetErrorElement(Page)).ToBeVisibleAsync();
        }
    }
}