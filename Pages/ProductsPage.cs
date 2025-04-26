using Microsoft.Playwright;

namespace PlaywrightNetEx.Pages
{
    class ProductsPage
    {
        private readonly IPage _page;
        public readonly ILocator Products;
        public readonly ILocator Descriptions;
        public readonly ILocator Prices;
        public readonly ILocator BtnsAddToCart;
        public readonly ILocator BtnShoppingCartBadge;

        public ProductsPage(IPage page)
        {
            _page = page;
            Products = _page.Locator("//div[@class='inventory_item']");
            Descriptions = _page.Locator("//div[@class='inventory_item_description']");
            Prices = _page.Locator("//div[@class='inventory_item_price']");
            BtnsAddToCart = _page.Locator("//button[contains(text(), 'Add to cart')]");
            BtnShoppingCartBadge = _page.Locator("//span[@class='shopping_cart_badge']");
        }

        public async Task AddAllProductsToCart()
        {
            foreach (var button in await BtnsAddToCart.ElementHandlesAsync())
            {
                await button.ClickAsync();
            }
        }

        public async Task ClickOnCart()
        {
            await BtnShoppingCartBadge.ClickAsync();
        }
    }
}
