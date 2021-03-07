using NUnit.Framework;

using SampleWebTest.Pages;
using SampleWebTest.Pages.HomePage;


namespace SampleWebTest.Tests
{
    [TestFixture]
    [Category("FunctionalTests")]
    [Category("ShoppingCartTests")]
    class ShoppingCartTests: BaseTest
    {
        internal HomePage HomePage { get => new HomePage(Driver); }

        

        [Test]
        [Category("ShoppingCart")]
        [Description("Checks that when basket is empty there is an alert warning empty cart message")]
        [Property("Author", "Teodora_Georgieva")]
        public void CheckForEmptyCartWarningMessage()
        {
            HomePage.Open();
            HomePage.ClickOnTheCartButton();
            var myShoppingCart = new CartPage(Driver);
            Assert.IsTrue(myShoppingCart.EmptyCartMessage.Displayed);
            Assert.AreEqual("Your shopping cart is empty.", myShoppingCart.EmptyCartMessage.Text);
        }

        [Test]
        [Category("ShoppingCart")]
        [Description("Checks that when item is added to the shopping cart it is present in the Shopping Cart Page")]
        [Property("Author", "Teodora_Georgieva")]
        public void AddedItemBeingPresentInTheCart()
        {
            HomePage.Open();
            HomePage.AddFeaturedItemInTheCart();
            var myShoppingCart = new CartPage(Driver);
            var qtyIntheCart = myShoppingCart.GetCurrentQtyItemsInTheCart();
            Assert.AreEqual(1, qtyIntheCart);

        }

        
    }
}
