using Microsoft.Playwright;
using PlaywrightNetEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightNetEx.Pages
{
    class LoginPage
    {
        private readonly IPage _page;
        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task CreateNewUser(User user)
        {
            await _page.FillAsync("input[name='name']", user.FirstName);
            await _page.FillAsync("//div[@class='signup-form']//input[@name='email']", user.Email);
            await _page.ClickAsync("//div[@class='signup-form']//button[@type='submit']");
        }

        public async Task FillSignupForm(User user)
        {
            switch (user.Gender)
            {
                case 'M':
                    break;
                case 'F':
                    break;
                default:
                    break;
            }

            await _page.FillAsync("input[name='password']", user.Password);
            if (user.Newsletter)
            {
                await _page.CheckAsync("input[name='newsletter']");
            }
            if (user.SpecialOffers)
            {
                await _page.CheckAsync("input[name='optin']");
            }
            await _page.FillAsync("input[name='first_name']", user.FirstName);


        }

        public async Task LoginAsync(User user)
        {
            await _page.FillAsync("//div[@class='login-form']//input[@name='email']", user.Email);
            await _page.FillAsync("input[name='password']", user.Password);
            await _page.ClickAsync("//div[@class='login-form']//button[@type='submit']");
        }
    }
}
