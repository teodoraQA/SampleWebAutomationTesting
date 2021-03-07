using OpenQA.Selenium;
using SampleWebTest.Pages;


namespace SampleWebTest.Pages
{
    public class ContactUsPage : BasePage
    {
        public ContactUsPage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement ContactUsHeader => Driver.FindElement(By.XPath("//*[@class= 'page-heading bottom-indent']"));
        protected IWebElement ContactUsForm => Driver.FindElement(By.ClassName("//*[@class= 'contact-form-box']"));

        internal bool IsLoaded()
        {
            if (!ContactUsHeader.Displayed && !ContactUsForm.Displayed)
            {
                return false;
            }
            return true;
        }
    }
}