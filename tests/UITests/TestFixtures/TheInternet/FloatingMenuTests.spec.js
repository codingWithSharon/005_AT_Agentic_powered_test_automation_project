const { test, expect } = require('@playwright/test');
const { FloatingMenuPage } = require('../../PageObjectModels/TheInternetPages/FloatingMenuPage');

test.describe('Floating Menu', () => {
  let floatingMenuPage;

  test.beforeEach(async ({ page }) => {
    floatingMenuPage = new FloatingMenuPage(page);
    await floatingMenuPage.navigate();
  });

  // Functional: all four nav links are visible on page load
  test('FloatingMenu_ShouldBeVisible_OnPageLoad', async () => {
    expect(await floatingMenuPage.isMenuVisible()).toBe(true);
    console.log('Tested: All four floating menu links (Home, News, Contact, About) are visible on page load.');
  });

  // Functional: menu remains visible after scrolling to bottom of page
  test('FloatingMenu_ShouldRemainVisible_AfterScroll', async () => {
    expect(await floatingMenuPage.isMenuVisibleAfterScroll()).toBe(true);
    console.log('Tested: The floating menu remains visible after scrolling to the bottom of the page.');
  });

  // Functional: Home link is clickable without error
  test('FloatingMenu_HomeLink_ShouldBeClickable', async () => {
    await floatingMenuPage.clickNavLink('Home');
    console.log('Tested: Clicking the "Home" link in the floating menu completes without throwing an error.');
  });

  // Functional: all four links (Home, News, Contact, About) are visible
  test('FloatingMenu_AllLinks_ShouldBeVisible', async () => {
    expect(await floatingMenuPage.isMenuVisible()).toBe(true);
    console.log('Tested: All four links — Home, News, Contact, and About — are visible in the floating menu.');
  });
});
