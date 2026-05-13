const { BasePage } = require('./BasePage');

class CheckboxesPage extends BasePage {
  constructor(page) {
    super(page);
    this.url = '/checkboxes';
    this.checkboxes = page.getByRole('checkbox');
  }

  async navigate() {
    await this.navigateTo(this.url);
  }

  async isCheckboxChecked(index) {
    return this.checkboxes.nth(index).isChecked();
  }

  async toggleCheckbox(index) {
    await this.checkboxes.nth(index).click();
  }
}

module.exports = { CheckboxesPage };
