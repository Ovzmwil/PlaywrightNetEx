using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;

namespace PlaywrightNetEx.Utils
{
    public static class ExtentManager
    {
        private static ExtentReports extent;
        private static ExtentSparkReporter reporter;

        public static ExtentReports GetInstance()
        {
            if (extent == null)
            {
                var reportPath = Path.Combine(
                    Environment.CurrentDirectory,
                    "Reports",
                    "ExtentReport.html"
                );

                reporter = new ExtentSparkReporter(reportPath);
                reporter.Config.DocumentTitle = "Playwright Automation";
                reporter.Config.ReportName = "Test Execution Report";

                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }

            return extent;
        }
    }
}
