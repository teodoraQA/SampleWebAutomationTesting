using NUnit.Framework;
using OpenQA.Selenium;
using SampleWebTest.Pages;
using SampleWebTest.Pages.HomePage;
using System.Collections.Generic;

namespace SampleWebTest.Tests
{
    [TestFixture]
    [Category("FunctionalTests")]
    [Category("HomePageTests")]

    public class HomePageTests : BaseTest
    {
        public string ItemToSearch { get; set; }
        internal HomePage HomePage { get => new HomePage(Driver); }

        [Test]
        [Category("SearchFunction")]
        [Description("Checks to make sure that search function returns valid results")]
        [Property("Author", "Teodora_Georgieva")]
        public void ValidSearchFunction()
        {
            HomePage.Open();
            ItemToSearch = "blouse";

            var resultPage = HomePage.SearchItem(ItemToSearch);
            Assert.IsTrue(resultPage.SearchResultPageLoaded);
            Assert.IsTrue(resultPage.SearchedItemLoaded(ItemToSearch), $"No results were found for your search {ItemToSearch}");
        }

        [Test]
        [Category("SearchFunction")]
        [Description("Checks to make sure that search function returns error message when searched item is not found")]
        [Property("Author", "Teodora_Georgieva")]
        public void InvalidSearchFunction()
        {
            HomePage.Open();
            ItemToSearch = "blose";

            var resultPage = HomePage.SearchItem(ItemToSearch);
            Assert.IsTrue(resultPage.SearchErrorMessage.Displayed);
            Assert.IsFalse(resultPage.SearchedItemLoaded(ItemToSearch));
        }

        [Test]
        [Category("HeaderNavigationLinks")]
        [Description("Checks to make sure that header links work- load valid pages")]
        [Property("Author", "Teodora_Georgieva")]
        public void HomePageContactUsNavigationLink()
        {
            HomePage.Open();
            HomePage.Header.ClickContactUsLink();
            var contactUsPage = new ContactUsPage(Driver);
            Assert.AreEqual("Contact us - My Store", Driver.Title);
            Assert.IsTrue(contactUsPage.IsLoaded());
        }

        [Test]
        [Category("HeaderNavigationLinks")]
        [Description("Checks to make sure that header links work- load valid pages")]
        [Property("Author", "Teodora_Georgieva")]
        public void HomePageSignInNavigationLink()
        {
            HomePage.Open();
            HomePage.Header.ClickSignInLink();
            var signIn = new SignInPage(Driver);
            Assert.AreEqual("Login - My Store", Driver.Title);
            Assert.IsTrue(signIn.IsLoaded());
        }

        [Test]
        [Category("ImageLinks")]
        [Description("Checks to make sure that slider image's buttons change image successfully")]
        [Property("Author", "Teodora_Georgieva")]
        public void SliderNextImageButtonValidFunctioning()
        {
            HomePage.Open();
            string currentImage = HomePage.SliderImages.CurrentImage;
            HomePage.SliderImages.NextImageButton.Click();
            string nextImage = HomePage.SliderImages.CurrentImage;
            Assert.IsTrue(HomePage.SliderImages.CheckIfImagesChange(currentImage, nextImage));
        }

        [Test]
        [Category("ImageLinks")]
        [Description("Checks to make sure that slider image's buttons change image successfully")]
        [Property("Author", "Teodora_Georgieva")]
        public void SliderPreviousImageButtonValidFunctioning()
        {
            HomePage.Open();
            string currentImage = HomePage.SliderImages.CurrentImage;
            HomePage.SliderImages.PrevImageButton.Click();
            string nextImage = HomePage.SliderImages.CurrentImage;
            Assert.IsTrue(HomePage.SliderImages.CheckIfImagesChange(currentImage, nextImage));
        }

        [Test]
        [Category("FeaturedItems")]
        [Description("Checks to make sure that HP featured items are present and fetured items tabs are active")]
        [Property("Author", "Teodora_Georgieva")]
        public void HomePageFeaturedItemsPresence()
        {
            HomePage.Open();
            Assert.IsTrue(HomePage.FeaturedItemsSection.Displayed);
            Assert.IsTrue(HomePage.FeaturedItemsHomeTabs.Enabled);
        }

        [Test]
        [Category("FeaturedItems")]
        [Description("Checks to make sure that HP featured items tabs change featured items content")]
        [Property("Author", "Teodora_Georgieva")]
        public void HomePageFeaturedItemsTabsContent()
        {
            HomePage.Open();
            Assert.IsTrue(HomePage.FeaturedItemsPopularTab.Enabled);
            var currentCollection = HomePage.GetCurrentFeaturedItemsCollection();
            var currentCollectionClass = HomePage.GetCurrentFeaturedItemsCollectionClass(currentCollection);
            HomePage.FeaturedItemsBestSellersTab.Click();
            var nextCollection = HomePage.GetCurrentFeaturedItemsCollection();
            var nextCollectionClass = HomePage.GetCurrentFeaturedItemsCollectionClass(nextCollection);
            Assert.AreNotEqual(nextCollectionClass, currentCollectionClass);
        }

        [Test]
        [Category("ImagesThumbnails")]
        [Description("Checks to make sure that all image thumbnails are present")]
        [Property("Author", "Teodora_Georgieva")]
        public void ImgThumbnailsPresent()
        {
            HomePage.Open();
           var imgCollection = HomePage.ImgSection.ImageThumbnails;
            Assert.AreEqual(7, imgCollection.Count);     
        }


        [Test]
        [Category("CartButtonTest")]
        [Description("Checks to make sure that clicking the cart button from the HP you are redirected to the CartPage")]
        [Property("Author", "Teodora_Georgieva")]
        public void CartButtonFunctioning()
        {
            HomePage.Open();
            HomePage.ClickOnTheCartButton();
            var myCartPage = new CartPage(Driver);
            Assert.AreEqual("Order - My Store", Driver.Title);
            Assert.IsTrue(myCartPage.IsLoaded());
        }
    }
}