using Microsoft.Playwright.NUnit;

namespace PlaywrightNetEx.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    class ProductsTests : PageTest
    {
        [SetUp]
        public async Task SetUp()
        {
            await Page.SetViewportSizeAsync(1280, 720);
            await Page.GotoAsync("https://www.saucedemo.com");
        }
    }
}
