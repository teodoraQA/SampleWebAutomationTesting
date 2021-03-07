using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace SampleWebTest.Pages.HomePage
{
    internal class HomePage :BasePage
    {
        public HomePage(IWebDriver driver): base(driver)
        {
        }

        public IWebElement SearchBar => Driver.FindElement(By.Id("search_query_top"));
        public IWebElement CartButton => Driver.FindElement(By.XPath("//a[@title= 'View my shopping cart']"));
        public ImgSections ImgSection => new ImgSections(Driver);
        public IWebElement FeaturedItemsSection => Driver.FindElement(By.Id("homefeatured"));
        public  IWebElement FeaturedItemsCollection { get; set; }
        //public IEnumerable<IWebElement> FeaturedItems => Driver.FindElements(By.XPath("//*[@class='product-container']"));

        public IWebElement GetCurrentFeaturedItemsCollection()
        {
            if (FeaturedItemsPopularTab.Enabled)
            {
                return FeaturedItemsCollection = Driver.FindElement(By.Id("homefeatured"));
            }
            else
            {
                return FeaturedItemsCollection = Driver.FindElement(By.Id("blockbestsellers"));
            }
        }

        public string GetCurrentFeaturedItemsCollectionClass(IWebElement featuredItemsCollection)
        {
            string currentFeaturedCollectionClass = featuredItemsCollection.GetAttribute("class");
            return currentFeaturedCollectionClass;
        }



        public IWebElement FeaturedItemsHomeTabs => Driver.FindElement(By.Id("home-page-tabs"));
        public IWebElement FeaturedItemsPopularTab => Driver.FindElement(By.XPath("//a[@class='homefeatured']"));
        public IWebElement FeaturedItemsBestSellersTab => Driver.FindElement(By.XPath("//a[@class='blockbestsellers']"));

        public HeaderSection Header => new HeaderSection(Driver);
        public Slider SliderImages => new Slider(Driver);

        internal void Open()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        internal SearchResultPage SearchItem(string itemToSearch)
        {
            SearchBar.SendKeys(itemToSearch);
            //Driver.FindElement(By.XPath("//button[@name='submit_search']")).Click();
            SearchBar.Submit();
            Driver.Manage().Timeouts().ImplicitWait =TimeSpan.FromSeconds(2);
            return new SearchResultPage(Driver, itemToSearch);
        }

        internal CartPage ClickOnTheCartButton()
        {
            CartButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            return new CartPage(Driver);
        }

        internal void AddFeaturedItemInTheCart()
        {
            Actions mouseAction = new Actions(Driver);
            var itemFromfeaturedCollection = Driver.FindElements(By.XPath("//*[@class='product-container']"));
            mouseAction.MoveToElement(itemFromfeaturedCollection[0]).Build().Perform();
            var addToCartButton = Driver.FindElement(By.XPath("//*[@data-id-product='1']"));
            mouseAction.MoveToElement(addToCartButton).Click().Build().Perform();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            var proceedToCheckOutButton = Driver.FindElement(By.XPath("//*[@title='Proceed to checkout']"));
            proceedToCheckOutButton.Click();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
          
        }

    }
}