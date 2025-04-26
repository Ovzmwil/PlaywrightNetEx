using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightNetEx.Pages;
using System.Reflection.Emit;

namespace PlaywrightNetEx.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    class ProductsTests : PageTest
    {
        [SetUp]
        public async Task SetUp()
        {
            var loginPage = new LoginPage(Page);
            await loginPage.GoToLoginPage();
            await loginPage.LoginStandardUser();
        }

        [Test]
        public async Task SixProductsArePresent()
        {
            await Expect(Page.Locator("//div[@class='inventory_item']")).ToHaveCountAsync(6);
        }

        [Test]
        public async Task DescriptionsArePresent()
        {
            await Expect(Page.Locator("//div[@class='inventory_item_description']")).ToHaveCountAsync(6);
        }

        [Test]
        public async Task PricesArePresent()
        {
            await Expect(Page.Locator("//div[@class='inventory_item_price']")).ToHaveCountAsync(6);
        }

        [Test]
        public async Task AddAllProductsToCart()
        {
            var addToCartButtons = Page.Locator("//button[contains(text(), 'Add to cart')]");
            foreach (var button in await addToCartButtons.ElementHandlesAsync())
            {
                await button.ClickAsync();
            }
            await Expect(Page.Locator("//span[@class='shopping_cart_badge']")).ToHaveTextAsync("6");
        }
    }
}
