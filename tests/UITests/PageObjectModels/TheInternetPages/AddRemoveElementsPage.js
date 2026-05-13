const { BasePage } = require('./BasePage');

class AddRemoveElementsPage extends BasePage {
  constructor(page) {
    super(page);
    this.url = '/add_remove_elements/';
    this.addElementButton = page.getByRole('button', { name: 'Add Element' });
    this.deleteButtons = page.getByRole('button', { name: 'Delete' });
  }

  async navigate() {
    await this.navigateTo(this.url);
  }

  async clickAddElement() {
    await this.addElementButton.click();
  }

  async clickDeleteButton(index) {
    await this.deleteButtons.nth(index).click();
  }

  async getDeleteButtonCount() {
    return this.deleteButtons.count();
  }
}

module.exports = { AddRemoveElementsPage };
