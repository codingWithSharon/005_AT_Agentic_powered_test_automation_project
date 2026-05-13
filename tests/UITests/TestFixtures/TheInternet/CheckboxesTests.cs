using NUnit.Framework;
using Tests.UITests.PageObjectModels.TheInternetPages;

namespace Tests.UITests.TestFixtures.TheInternet;

[TestFixture]
public class CheckboxesTests : Setup
{
    private CheckboxesPage _page = null!;

    [SetUp]
    public async Task SetUp()
    {
        _page = new CheckboxesPage(Page);
        await _page.Navigate();
    }

    // Functional: checkbox 1 is unchecked by default
    [Test]
    public async Task Checkbox1_DefaultState_ShouldBeUnchecked()
    {
        bool isChecked = await _page.IsCheckboxChecked(0);
        Assert.That(() => isChecked, Is.False);
    }

    // Functional: checkbox 2 is checked by default
    [Test]
    public async Task Checkbox2_DefaultState_ShouldBeChecked()
    {
        bool isChecked = await _page.IsCheckboxChecked(1);
        Assert.That(() => isChecked, Is.True);
    }

    // State Transition: unchecked → checked
    [Test]
    public async Task ToggleCheckbox1_ShouldBecomeChecked()
    {
        await _page.ToggleCheckbox(0);
        bool isChecked = await _page.IsCheckboxChecked(0);
        Assert.That(() => isChecked, Is.True);
    }

    // State Transition: checked → unchecked
    [Test]
    public async Task ToggleCheckbox2_ShouldBecomeUnchecked()
    {
        await _page.ToggleCheckbox(1);
        bool isChecked = await _page.IsCheckboxChecked(1);
        Assert.That(() => isChecked, Is.False);
    }
}
