using OpenQA.Selenium;
using System.Collections.Generic;


namespace SampleWebTest.Pages.HomePage
{
    class ImgSections: BasePage
    {
        public ImgSections(IWebDriver driver) : base(driver)
        {
        }

        public Slider SliderImage => new Slider(Driver);

        public IReadOnlyCollection<IWebElement> ImageThumbnails => Driver.FindElements(By.ClassName("item-img"));

        

    }
}
