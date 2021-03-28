using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FinalASM_TanNV23.Page
{
    class ShoppingPage : BasePage
    {
        public ShoppingPage(IWebDriver driver) : base(driver)
        { }


        #region Page Elements
        private IWebElement Imagerobot => findElements.CssElement(".peek");
        private IWebElement ShoppingCart => findElements.CssElement("#shopping_cart_container > a > svg");
        private IWebElement CartCounterLbl => findElements.CssElement("#shopping_cart_container > a > span");
        private IWebElement DescriptionOfProduct => findElements.CssElement("#inventory_container > div > div:nth-child(1) > div.inventory_item_label > div");
        private IWebElement AddtoCartBtn => findElements.CssElement("#inventory_container > div > div:nth-child(1) > div.pricebar > button");

        #endregion


        #region Page Actions
        public ShoppingPage ClickAddToCart()
        {
            this.AddtoCartBtn.Click();
            return this;
        }
        public CartPage NavigateCart()
        {
            this.ShoppingCart.Click();
            return new CartPage(this.driver);
        }
        public bool CounterProduct()
        {
            if (this.CartCounterLbl.Text == "1")
                return true;
            else return false;                    
        }
        public string GetDescriptionProduct()
        {
            return this.DescriptionOfProduct.Text;
        }
        public bool IsDisplayShoppingPage()
        {
            try
            {
                return this.Imagerobot.Displayed;
            }
            catch 
            {

                return false;
            }
        }
        #endregion
    }
}
