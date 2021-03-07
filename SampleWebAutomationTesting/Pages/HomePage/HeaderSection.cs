using OpenQA.Selenium;
using System;



namespace SampleWebTest.Pages.HomePage
{
    internal class HeaderSection : HomePage
    {
        public HeaderSection(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement ContactUsLink => Driver.FindElement(By.CssSelector("#contact-link > a"));
        public IWebElement SignInLink => Driver.FindElement(By.XPath("//*[@class='header_user_info']/a"));

        public ContactUsPage ClickContactUsLink()
        {
            ContactUsLink.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            return new ContactUsPage(Driver);
        }

        internal SignInPage ClickSignInLink()
        {
            SignInLink.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            return new SignInPage(Driver);

        }
    }
}