using Microsoft.Playwright.NUnit;
using PlaywrightNetEx.Pages;

namespace PlaywrightNetEx.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    class CheckoutTests : PageTest
    {
        private const string thankingMessage = "Thank you for your order!";

        private LoginPage _loginPage;
        private ProductsPage _productsPage;
        private CheckoutPage _checkoutPage;

        [SetUp]
        public async Task SetUp()
        {
            _loginPage = new LoginPage(Page);
            _productsPage = new ProductsPage(Page);
            _checkoutPage = new CheckoutPage(Page);

            await _loginPage.GoToLoginPage();
            await _loginPage.LoginStandardUser();
            await _productsPage.AddAllProductsToCart();
            await _productsPage.ClickOnCart();
        }

        [Test]
        [TestCase("Leandro", "Santana", "12231000")]
        public async Task SucessFullCheckout(string firstName, string lastName, string postalCode)
        {
            await _checkoutPage.ClickOnCheckout();
            await _checkoutPage.FillClientInformation(firstName, lastName, postalCode);
            await _checkoutPage.ClickOnContinue();
            await _checkoutPage.ClickOnFinish();
            await Expect(_checkoutPage.MsgThanking).ToHaveTextAsync(thankingMessage);
        }

        [Test]
        [TestCase("", "Santana", "12231000", TestName = "Missing FirstName")]
        [TestCase("Leandro", "", "12231000", TestName = "Missing LastName")]
        [TestCase("Leandro", "Santana", "", TestName = "Missing PostalCode")]
        public async Task MissingInformationCheckout(string firstName, string lastName, string postalCode)
        {
            await _checkoutPage.ClickOnCheckout();
            await _checkoutPage.FillClientInformation(firstName, lastName, postalCode);
            await _checkoutPage.ClickOnContinue();
            await Expect(_checkoutPage.BtnError).ToBeVisibleAsync();
        }
    }
}
