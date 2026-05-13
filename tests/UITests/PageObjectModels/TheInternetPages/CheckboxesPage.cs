using Microsoft.Playwright;

namespace Tests.UITests.PageObjectModels.TheInternetPages;

public class CheckboxesPage : BasePage
{
    private const string Url = "https://the-internet.herokuapp.com/checkboxes";

    private ILocator Checkboxes => Page.GetByRole(AriaRole.Checkbox);

    public CheckboxesPage(IPage page) : base(page) { }

    public async Task Navigate() => await NavigateTo(Url);

    public async Task<bool> IsCheckboxChecked(int index) => await Checkboxes.Nth(index).IsCheckedAsync();

    public async Task ToggleCheckbox(int index) => await Checkboxes.Nth(index).ClickAsync();
}
