using Microsoft.Playwright;
using PlaywrightNetEx.Models;

namespace PlaywrightNetEx.Pages
{
    class LoginPage
    {
        private readonly IPage _page;
        public readonly ILocator DivContainingPassword;
        public readonly ILocator TxtUserName;
        public readonly ILocator TxtPassword;
        public readonly ILocator BtnLogin;
        public readonly ILocator BtnError;

        public LoginPage(IPage page)
        {
            _page = page;
            DivContainingPassword = _page.Locator("//div[@class='login_password']");
            TxtUserName = _page.Locator("//input[@name='user-name']");
            TxtPassword = _page.Locator("//input[@name='password']");
            BtnLogin = _page.Locator("//input[@name='login-button']");
            BtnError = _page.Locator("//*[@class='error-button']");
        }

        public async Task GoToLoginPage()
        {
            await _page.SetViewportSizeAsync(1280, 720);
            await _page.GotoAsync("https://www.saucedemo.com");
        }
        public async Task<string> GetPassword()
        {
            var stringContainingPassword = await DivContainingPassword.TextContentAsync();
            var password = stringContainingPassword.Substring(stringContainingPassword.IndexOf(":") + 1);
            return password;
        }

        private async Task Login(string user)
        {
            await TxtUserName.FillAsync(user);
            await TxtPassword.FillAsync(await GetPassword());
            await BtnLogin.ClickAsync();
        }

        public async Task LoginStandardUser()
        {
            await Login(Users.StandardUser);
        }

        public async Task LoginLockedUser()
        {
            await Login(Users.LockedOutUser);
        }
    }
}
