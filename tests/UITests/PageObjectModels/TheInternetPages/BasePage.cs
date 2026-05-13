using Microsoft.Playwright;

namespace Tests.UITests.PageObjectModels.TheInternetPages;

public class BasePage
{
    protected readonly IPage Page;

    public BasePage(IPage page)
    {
        Page = page;
    }

    public async Task NavigateTo(string url) => await Page.GotoAsync(url);

    public async Task<string> GetTitle() => await Page.TitleAsync();
}
