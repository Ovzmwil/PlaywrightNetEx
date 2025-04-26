using Microsoft.Playwright;
using PlaywrightNetEx.Models;

namespace PlaywrightNetEx.Pages
{
    class LoginPage
    {
        public static async Task<string> GetPassword(IPage page)
        {
            var password = await page.Locator("//div[@class='login_password']").TextContentAsync();
            password = password.Substring(password.IndexOf(":") + 1);
            return password;
        }

        private static async Task Login(IPage page,string user)
        {
            await page.FillAsync("input[name='user-name']", user);
            await page.FillAsync("input[name='password']", await GetPassword(page));
            await page.ClickAsync("//input[@name='login-button']");
        }

        public static async Task LoginStandardUser(IPage page)
        {
            await Login(page, Users.StandardUser);
        }

        public static async Task LoginLockedUser(IPage page)
        {
            await Login(page, Users.LockedOutUser);
        }

        public static ILocator GetErrorElement(IPage page)
        {
            return page.Locator("//*[@class='error-button']");
        }
    }
}
