using OpenQA.Selenium;

namespace SampleWebTest.Pages.HomePage
{
    public class Slider : BasePage
    {
        public Slider(IWebDriver driver) : base(driver)
        {
        }
        public string CurrentImage => MainSliderImage.GetAttribute("style");
        public IWebElement NextImageButton => Driver.FindElement(By.ClassName("bx-next"));
        public IWebElement PrevImageButton => Driver.FindElement(By.ClassName("bx-prev"));

        private IWebElement MainSliderImage => Driver.FindElement(By.Id("homeslider"));

        public bool CheckIfImagesChange(string current, string next)
        {
            if (current != next)
            {
                return true;
            }
            return false;
        }

    }
}