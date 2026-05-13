using Microsoft.Playwright;

namespace Tests.UITests.PageObjectModels.TheInternetPages;

public class AddRemoveElementsPage : BasePage
{
    private const string Url = "https://the-internet.herokuapp.com/add_remove_elements/";

    private ILocator AddElementButton => Page.GetByRole(AriaRole.Button, new() { Name = "Add Element" });
    private ILocator DeleteButtons => Page.GetByRole(AriaRole.Button, new() { Name = "Delete" });

    public AddRemoveElementsPage(IPage page) : base(page) { }

    public async Task Navigate() => await NavigateTo(Url);

    public async Task ClickAddElement() => await AddElementButton.ClickAsync();

    public async Task ClickDeleteButton(int index) => await DeleteButtons.Nth(index).ClickAsync();

    public async Task<int> GetDeleteButtonCount() => await DeleteButtons.CountAsync();
}
