using Microsoft.Playwright;

namespace Tests.UITests.PageObjectModels.TheInternetPages;

public class FloatingMenuPage : BasePage
{
    private const string Url = "https://the-internet.herokuapp.com/floating_menu";

    private ILocator HomeLink => Page.GetByRole(AriaRole.Link, new() { Name = "Home" });
    private ILocator NewsLink => Page.GetByRole(AriaRole.Link, new() { Name = "News" });
    private ILocator ContactLink => Page.GetByRole(AriaRole.Link, new() { Name = "Contact" });
    private ILocator AboutLink => Page.GetByRole(AriaRole.Link, new() { Name = "About" });

    public FloatingMenuPage(IPage page) : base(page) { }

    public async Task Navigate() => await NavigateTo(Url);

    public async Task<bool> IsMenuVisible()
    {
        return await HomeLink.IsVisibleAsync()
            && await NewsLink.IsVisibleAsync()
            && await ContactLink.IsVisibleAsync()
            && await AboutLink.IsVisibleAsync();
    }

    public async Task ClickNavLink(string name) =>
        await Page.GetByRole(AriaRole.Link, new() { Name = name }).ClickAsync();

    public async Task<bool> IsMenuVisibleAfterScroll()
    {
        await Page.EvaluateAsync("window.scrollTo(0, document.body.scrollHeight)");
        return await IsMenuVisible();
    }
}
