const { BasePage } = require('./BasePage');

class FloatingMenuPage extends BasePage {
  constructor(page) {
    super(page);
    this.url = '/floating_menu';
    this.homeLink = page.getByRole('link', { name: 'Home' });
    this.newsLink = page.getByRole('link', { name: 'News' });
    this.contactLink = page.getByRole('link', { name: 'Contact' });
    this.aboutLink = page.getByRole('link', { name: 'About' });
  }

  async navigate() {
    await this.navigateTo(this.url);
  }

  async isMenuVisible() {
    return (
      (await this.homeLink.isVisible()) &&
      (await this.newsLink.isVisible()) &&
      (await this.contactLink.isVisible()) &&
      (await this.aboutLink.isVisible())
    );
  }

  async clickNavLink(name) {
    await this.page.getByRole('link', { name }).click();
  }

  async isMenuVisibleAfterScroll() {
    await this.page.evaluate(() => window.scrollTo(0, document.body.scrollHeight));
    return this.isMenuVisible();
  }
}

module.exports = { FloatingMenuPage };
