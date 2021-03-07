using OpenQA.Selenium;


namespace SampleWebTest.Pages
{
    internal class SearchResultPage : BasePage
    {
        protected string SearchedItem { get; set; }
        public SearchResultPage(IWebDriver driver, string searchedItem) : base(driver)
        {
            SearchedItem = searchedItem;
        }

       // internal IWebElement SearchedItemContainer => Driver.FindElement(By.XPath("//div[@class='product-container']"));
        internal IWebElement SearchErrorMessage => Driver.FindElement(By.XPath("//*[@class = 'alert alert-warning']"));




        public bool SearchResultPageLoaded => Driver.Url.Contains($"search_query={SearchedItem}");

        public bool SearchedItemLoaded(string itemToSearch)
        {

            switch (itemToSearch)
                {
                    case "blouse":
                        bool resultImageDisplayed = Driver.FindElement(By.XPath("//img[@title='Blouse']")).Displayed;
                        string firstResultItemTitle = Driver.FindElement(By.XPath("//*[@itemprop='name']/*[contains(text(),'Blouse')]")).Text;
                        if( resultImageDisplayed && (firstResultItemTitle.ToLower()=="blouse")) { return true; }
                    return false;

                default:
                    return false;
            } 
        }
    }

   
}