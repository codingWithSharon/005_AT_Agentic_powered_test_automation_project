using Microsoft.Playwright.NUnit;

namespace Tests;

public class Setup : PageTest
{
    protected const string BaseUrl = "https://the-internet.herokuapp.com";
}
