const { test, expect } = require('@playwright/test');
const { CheckboxesPage } = require('../../PageObjectModels/TheInternetPages/CheckboxesPage');

test.describe('Checkboxes', () => {
  let checkboxesPage;

  test.beforeEach(async ({ page }) => {
    checkboxesPage = new CheckboxesPage(page);
    await checkboxesPage.navigate();
  });

  // Functional: checkbox 1 is unchecked by default
  test('Checkbox1_DefaultState_ShouldBeUnchecked', async () => {
    expect(await checkboxesPage.isCheckboxChecked(0)).toBe(false);
    console.log('Tested: Checkbox 1 is unchecked by default on page load.');
  });

  // Functional: checkbox 2 is checked by default
  test('Checkbox2_DefaultState_ShouldBeChecked', async () => {
    expect(await checkboxesPage.isCheckboxChecked(1)).toBe(true);
    console.log('Tested: Checkbox 2 is checked by default on page load.');
  });

  // State Transition: unchecked → checked
  test('ToggleCheckbox1_ShouldBecomeChecked', async () => {
    await checkboxesPage.toggleCheckbox(0);
    expect(await checkboxesPage.isCheckboxChecked(0)).toBe(true);
    console.log('Tested: Clicking Checkbox 1 transitions it from unchecked to checked.');
  });

  // State Transition: checked → unchecked
  test('ToggleCheckbox2_ShouldBecomeUnchecked', async () => {
    await checkboxesPage.toggleCheckbox(1);
    expect(await checkboxesPage.isCheckboxChecked(1)).toBe(false);
    console.log('Tested: Clicking Checkbox 2 transitions it from checked to unchecked.');
  });
});
