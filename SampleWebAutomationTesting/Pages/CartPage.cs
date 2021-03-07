using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System;

namespace SampleWebTest.Pages
{
    internal class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        public  IWebElement EmptyCartMessage => Driver.FindElement(By.XPath("//*[@class= 'alert alert-warning']"));

        public IWebElement CartSummaryTitle => Driver.FindElement(By.Id("cart_title"));
        public IWebElement CartSummaryQtyInTheCart => Driver.FindElement(By.Id("summary_products_quantity"));

        public bool IsLoaded()
        {
            return CartSummaryTitle.Displayed;
        }

        public int GetCurrentQtyItemsInTheCart()
        {
            string qtyProductsAsText = CartSummaryQtyInTheCart.Text;
            string regexPattern = "^[0-9]*";
            Regex regex = new Regex(regexPattern);
            Match qtyMatch = regex.Match(qtyProductsAsText);
            int qtyProducts = Convert.ToInt32(qtyMatch.Value);
            return qtyProducts;  
        }
    }
}