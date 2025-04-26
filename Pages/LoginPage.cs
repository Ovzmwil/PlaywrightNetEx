using Microsoft.Playwright;
using PlaywrightNetEx.Models;

namespace PlaywrightNetEx.Pages
{
    class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToLoginPage()
        {
            await _page.SetViewportSizeAsync(1280, 720);
            await _page.GotoAsync("https://www.saucedemo.com");
        }
        public async Task<string> GetPassword()
        {
            var password = await _page.Locator("//div[@class='login_password']").TextContentAsync();
            password = password.Substring(password.IndexOf(":") + 1);
            return password;
        }

        private async Task Login(string user)
        {
            await _page.FillAsync("input[name='user-name']", user);
            await _page.FillAsync("input[name='password']", await GetPassword());
            await _page.ClickAsync("//input[@name='login-button']");
        }

        public async Task LoginStandardUser()
        {
            await Login(Users.StandardUser);
        }

        public async Task LoginLockedUser()
        {
            await Login(Users.LockedOutUser);
        }

        public ILocator GetErrorElement()
        {
            return _page.Locator("//*[@class='error-button']");
        }
    }
}
