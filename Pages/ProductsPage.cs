using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightNetEx.Pages
{
    class ProductsPage
    {
        private readonly IPage _page;
        public readonly ILocator Products;
        public readonly ILocator Descriptions;
        public readonly ILocator Prices;
        public readonly ILocator AddToCartButtons;
        public readonly ILocator ShoppingCartBadge;

        public ProductsPage(IPage page)
        {
            _page = page;
            Products = _page.Locator("//div[@class='inventory_item']");
            Descriptions = _page.Locator("//div[@class='inventory_item_description']");
            Prices = _page.Locator("//div[@class='inventory_item_price']");
            AddToCartButtons = _page.Locator("//button[contains(text(), 'Add to cart')]");
            ShoppingCartBadge = _page.Locator("//span[@class='shopping_cart_badge']");
        }

        public async Task AddAllProductsToCart()
        {
            foreach (var button in await AddToCartButtons.ElementHandlesAsync())
            {
                await button.ClickAsync();
            }
        }
    }
}
