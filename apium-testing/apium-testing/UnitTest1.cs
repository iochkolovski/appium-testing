using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;

namespace apium_testing
{
    public class Tests
    {
        private const string AppiumServerUri = "http://localhost:8080/wd/hub/";
        private const string SummatorAppPath = @"C:\Users\poods\Desktop\softuni!\SummatorDesktopApp.exe";
        private WindowsDriver<WindowsElement> driver;

        [OneTimeSetUp]
        public void Setup()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("PlatformName", "Windows");
            appiumOptions.AddAdditionalCapability("app", SummatorAppPath);
            driver = new WindowsDriver<WindowsElement>(new Uri(AppiumServerUri), appiumOptions);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test_CanSum_Two_PositiveNumbers()
        {
            var firstFieldNum = driver.FindElementByAccessibilityId("textBoxFirstNum");
            firstFieldNum.Clear();
        }
    }
}