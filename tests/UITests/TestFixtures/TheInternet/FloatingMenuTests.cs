using NUnit.Framework;
using Tests.UITests.PageObjectModels.TheInternetPages;

namespace Tests.UITests.TestFixtures.TheInternet;

[TestFixture]
public class FloatingMenuTests : Setup
{
    private FloatingMenuPage _page = null!;

    [SetUp]
    public async Task SetUp()
    {
        _page = new FloatingMenuPage(Page);
        await _page.Navigate();
    }

    // Functional: all four nav links are visible on page load
    [Test]
    public async Task FloatingMenu_ShouldBeVisible_OnPageLoad()
    {
        bool isVisible = await _page.IsMenuVisible();
        Assert.That(() => isVisible, Is.True);
    }

    // Functional: menu remains visible after scrolling to bottom of page
    [Test]
    public async Task FloatingMenu_ShouldRemainVisible_AfterScroll()
    {
        bool isVisible = await _page.IsMenuVisibleAfterScroll();
        Assert.That(() => isVisible, Is.True);
    }

    // Functional: Home link is clickable without throwing an exception
    [Test]
    public async Task FloatingMenu_HomeLink_ShouldBeClickable()
    {
        await _page.ClickNavLink("Home");
    }

    // Functional: all four links (Home, News, Contact, About) are visible
    [Test]
    public async Task FloatingMenu_AllLinks_ShouldBeVisible()
    {
        bool isVisible = await _page.IsMenuVisible();
        Assert.That(() => isVisible, Is.True);
    }
}
