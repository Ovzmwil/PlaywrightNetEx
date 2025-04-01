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
            await Page.GotoAsync("https://playwright.dev");
            HomePage homePage = new(Page);
            await homePage.goToLoginPage();
        }

        [Test]
        public async Task CreateNewUser()
        {
            await Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
        }

        [Test]
        public async Task GetStartedLink()
        {
            await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
        }
    }
}