using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace SampleWebTest.Tests
{
    public class BaseTest
    {
        public IWebDriver Driver { get; private set; }

        [SetUp]
        public void Setup()
        {
            var driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Driver = new ChromeDriver(driverPath);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Close();
            Driver.Quit();
            
        }
    }
}