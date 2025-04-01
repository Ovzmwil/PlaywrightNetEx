using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlaywrightNetEx.Pages
{
    class HomePage
    {
        private readonly IPage _page;
        public HomePage(IPage page)
        {
            _page = page;
        }

        public async Task goToLoginPage()
        {
            await _page.ClickAsync("a[href='/login']");
        }
    }
}
