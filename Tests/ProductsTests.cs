﻿using Microsoft.Playwright.NUnit;
using PlaywrightNetEx.Pages;

namespace PlaywrightNetEx.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    class ProductsTests : PageTest
    {
        private const int expectedProductsNumber = 6;

        private ProductsPage _productsPage;
        private LoginPage _loginPage;

        [SetUp]
        public async Task SetUp()
        {
            _loginPage = new LoginPage(Page);
            _productsPage = new ProductsPage(Page);

            await _loginPage.GoToLoginPage();
            await _loginPage.LoginStandardUser();
        }

        [Test]
        public async Task SixProductsArePresent()
        {
            await Expect(_productsPage.Products).ToHaveCountAsync(expectedProductsNumber);
        }

        [Test]
        public async Task DescriptionsArePresent()
        {
            await Expect(_productsPage.Descriptions).ToHaveCountAsync(expectedProductsNumber);
        }

        [Test]
        public async Task PricesArePresent()
        {
            await Expect(_productsPage.Prices).ToHaveCountAsync(expectedProductsNumber);
        }

        [Test]
        public async Task AddAllProductsToCart()
        {
            await _productsPage.AddAllProductsToCart();
            await Expect(_productsPage.BtnShoppingCartBadge).ToHaveTextAsync(expectedProductsNumber.ToString());
        }
    }
}
