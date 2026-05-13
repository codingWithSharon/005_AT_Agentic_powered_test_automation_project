const { test, expect } = require('@playwright/test');
const { AddRemoveElementsPage } = require('../../PageObjectModels/TheInternetPages/AddRemoveElementsPage');

test.describe('Add Remove Elements', () => {
  let addRemovePage;

  test.beforeEach(async ({ page }) => {
    addRemovePage = new AddRemoveElementsPage(page);
    await addRemovePage.navigate();
  });

  // Functional: adding one element creates exactly one Delete button
  test('AddOneElement_ShouldShowDeleteButton', async () => {
    await addRemovePage.clickAddElement();
    expect(await addRemovePage.getDeleteButtonCount()).toBe(1);
    console.log('Tested: Clicking "Add Element" once creates exactly 1 Delete button on the page.');
  });

  // Boundary Value: add 5 elements and confirm all are present
  test('AddMultipleElements_ShouldShowCorrectCount', async () => {
    for (let i = 0; i < 5; i++) {
      await addRemovePage.clickAddElement();
    }
    expect(await addRemovePage.getDeleteButtonCount()).toBe(5);
    console.log('Tested: Clicking "Add Element" 5 times results in exactly 5 Delete buttons visible.');
  });

  // Functional: deleting one element reduces the count by one
  test('RemoveElement_ShouldDecreaseCount', async () => {
    await addRemovePage.clickAddElement();
    await addRemovePage.clickAddElement();
    await addRemovePage.clickDeleteButton(0);
    expect(await addRemovePage.getDeleteButtonCount()).toBe(1);
    console.log('Tested: Adding 2 elements then deleting 1 leaves exactly 1 Delete button remaining.');
  });

  // Boundary Value: deleting all elements leaves none remaining
  test('RemoveAllElements_ShouldShowNoneRemaining', async () => {
    for (let i = 0; i < 3; i++) {
      await addRemovePage.clickAddElement();
    }
    const total = await addRemovePage.getDeleteButtonCount();
    for (let i = 0; i < total; i++) {
      await addRemovePage.clickDeleteButton(0);
    }
    expect(await addRemovePage.getDeleteButtonCount()).toBe(0);
    console.log('Tested: Adding 3 elements then deleting all of them leaves 0 Delete buttons on the page.');
  });
});
