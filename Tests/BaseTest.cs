using AventStack.ExtentReports;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightNetEx.Utils;


namespace PlaywrightNetEx.Tests
{
    public class BaseTest : PageTest
    {
        protected static ExtentReports extent;
        protected ExtentTest test;

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            extent = ExtentManager.GetInstance();
        }

        [SetUp]
        public async Task Setup()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public async Task TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                var screenshotPath = await TakeScreenshot();
                test.Fail("Test Failed")
                    .AddScreenCaptureFromPath(screenshotPath);
            }
            else
            {
                test.Pass("Test Passed");
            }
        }

        [OneTimeTearDown]
        public async Task GlobalTearDown()
        {
            extent.Flush();
        }

        private async Task<string> TakeScreenshot()
        {
            var path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "Reports",
                $"{TestContext.CurrentContext.Test.Name}.png"
            );

            await Page.ScreenshotAsync(new PageScreenshotOptions
            {
                Path = path
            });

            return path;
        }
    }
}
