using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace apium_testing
{
    public class Tests
    {
        private const string AppiumServerUri = "http://127.0.0.1:4723/wd/hub";
        private const string App = @"C:\com.example.androidappsummator.apk";
        private AppiumOptions options;
        private AndroidDriver<AndroidElement> driver;
        private AndroidElement firstField;
        private AndroidElement secondField;
        private AndroidElement resultField;
        private AndroidElement sumButton;

        [OneTimeSetUp]
        public void OpenApp()
        {
            options = new AppiumOptions() { PlatformName = "Android" };
            options.AddAdditionalCapability("app", App);
            driver = new AndroidDriver<AndroidElement>(new Uri(AppiumServerUri), options);
            firstField = driver.FindElementById("com.example.androidappsummator:id/editText1");
            secondField = driver.FindElementById("com.example.androidappsummator:id/editText2");
            resultField = driver.FindElementById("com.example.androidappsummator:id/editTextSum");
            sumButton = driver.FindElementById("com.example.androidappsummator:id/buttonCalcSum");
        }

        [SetUp]
        public void ClearFields()
        {
            firstField.Clear();
            secondField.Clear();
            resultField.Clear();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.CloseApp();
            driver.Quit();
        }

        [Test]
        public void Test_Sums_Two_PositiveNumbers()
        {
            firstField.SendKeys("2");
            secondField.SendKeys("3");
            sumButton.Click();
            Assert.That(resultField.Text, Is.EqualTo("5"));
        }

        [Test]
        public void Test_GetErrorMessage_When_TextIsGivenAsInput_FirstField()
        {
            firstField.SendKeys("Hello");
            secondField.SendKeys("2");
            sumButton.Click();
            Assert.That(resultField.Text, Is.EqualTo("error"));
        }

        [Test]
        public void Test_GetErrorMessage_When_TextIsGivenAsInput_SecondField()
        {
            firstField.SendKeys("2");
            secondField.SendKeys("Hello");
            sumButton.Click();
            Assert.That(resultField.Text, Is.EqualTo("error"));
        }

        [Test]
        public void Test_GetErrorMessage_When_TextIsGivenAsInput_BothFields()
        {
            firstField.SendKeys("Hello");
            secondField.SendKeys("World");
            sumButton.Click();
            Assert.That(resultField.Text, Is.EqualTo("error"));
        }

        [Test]
        public void Test_GetErrorMessage_When_IsEmpty_BothFields()
        {
            sumButton.Click();
            Assert.That(resultField.Text, Is.EqualTo("error"));
        }

        [Test]
        public void Test_GetErrorMessage_When_IsEmpty_OneField()
        {
            sumButton.Click();
            Assert.That(resultField.Text, Is.EqualTo("error"));
        }
    }
}