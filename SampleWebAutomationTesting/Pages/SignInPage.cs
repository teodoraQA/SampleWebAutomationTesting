using OpenQA.Selenium;

namespace SampleWebTest.Pages

{
    internal class SignInPage : BasePage
    {

        public SignInPage(IWebDriver driver) : base(driver)
        {
        }

        protected IWebElement CreateAccountForm => Driver.FindElement(By.Id("create-account_form"));
        protected IWebElement LoginForm => Driver.FindElement(By.Id("login_form"));

        internal bool IsLoaded()
        {
            if (!CreateAccountForm.Displayed && !LoginForm.Displayed)
            {
                return false;
            }
            return true;
        }
    }
}