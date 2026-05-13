using NUnit.Framework;
using Tests.UITests.PageObjectModels.TheInternetPages;

namespace Tests.UITests.TestFixtures.TheInternet;

[TestFixture]
public class AddRemoveElementsTests : Setup
{
    private AddRemoveElementsPage _page = null!;

    [SetUp]
    public async Task SetUp()
    {
        _page = new AddRemoveElementsPage(Page);
        await _page.Navigate();
    }

    // Functional: adding one element creates exactly one Delete button
    [Test]
    public async Task AddOneElement_ShouldShowDeleteButton()
    {
        await _page.ClickAddElement();
        int count = await _page.GetDeleteButtonCount();
        Assert.That(() => count, Is.EqualTo(1));
    }

    // Boundary Value: add 5 elements and confirm all are present
    [Test]
    public async Task AddMultipleElements_ShouldShowCorrectCount()
    {
        for (int i = 0; i < 5; i++)
            await _page.ClickAddElement();

        int count = await _page.GetDeleteButtonCount();
        Assert.That(() => count, Is.EqualTo(5));
    }

    // Functional: deleting one element reduces the count by one
    [Test]
    public async Task RemoveElement_ShouldDecreaseCount()
    {
        await _page.ClickAddElement();
        await _page.ClickAddElement();
        await _page.ClickDeleteButton(0);

        int count = await _page.GetDeleteButtonCount();
        Assert.That(() => count, Is.EqualTo(1));
    }

    // Boundary Value: deleting all elements leaves none remaining
    [Test]
    public async Task RemoveAllElements_ShouldShowNoneRemaining()
    {
        for (int i = 0; i < 3; i++)
            await _page.ClickAddElement();

        int total = await _page.GetDeleteButtonCount();
        for (int i = 0; i < total; i++)
            await _page.ClickDeleteButton(0);

        int remaining = await _page.GetDeleteButtonCount();
        Assert.That(() => remaining, Is.EqualTo(0));
    }
}
