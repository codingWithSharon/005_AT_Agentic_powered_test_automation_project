using NUnit.Framework;

[SetUpFixture]
public class GlobalSetup
{
    [OneTimeSetUp]
    public void GlobalOneTimeSetUp()
    {
        // Browsers installed globally via playwright.ps1 install
        // No PLAYWRIGHT_BROWSERS_PATH override needed
    }
}
