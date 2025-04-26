using Microsoft.Playwright;

namespace PlaywrightNetEx.Pages
{
    class CheckoutPage
    {
        private readonly IPage _page;
        public readonly ILocator BtnCheckout;
        public readonly ILocator TxtFirstName;
        public readonly ILocator TxtLastName;
        public readonly ILocator TxtPostalCode;
        public readonly ILocator BtnContinue;
        public readonly ILocator BtnFinish;
        public readonly ILocator MsgThanking;
        public readonly ILocator BtnError;

        public CheckoutPage(IPage page)
        {
            _page = page;
            BtnCheckout = _page.Locator("//button[@name='checkout']");
            TxtFirstName = _page.Locator("//input[@name='firstName']");
            TxtLastName = _page.Locator("//input[@name='lastName']");
            TxtPostalCode = _page.Locator("//input[@name='postalCode']");
            BtnContinue = _page.Locator("//input[@name='continue']");
            BtnFinish = _page.Locator("//button[@name='finish']");
            MsgThanking = _page.Locator("//h2[@class='complete-header']");
            BtnError = _page.Locator("//*[@class='error-button']");
        }

        public async Task ClickOnCheckout()
        {
            await BtnCheckout.ClickAsync();
        }

        public async Task FillFirstName(string firstName)
        {
            await TxtFirstName.FillAsync(firstName);
        }

        public async Task FillLastName(string lastName)
        {
            await TxtLastName.FillAsync(lastName);
        }

        public async Task FillPostalCode(string postalCode)
        {
            await TxtPostalCode.FillAsync(postalCode);
        }

        public async Task FillClientInformation(string firstName, string lastName, string postalCode)
        {
            await FillFirstName(firstName);
            await FillLastName(lastName);
            await FillPostalCode(postalCode);
        }

        public async Task ClickOnContinue()
        {
            await BtnContinue.ClickAsync();
        }

        public async Task ClickOnFinish()
        {
            await BtnFinish.ClickAsync();
        }
    }
}
