using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FinalASM_TanNV23.Page
{
    class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        { }

        #region Page Elements
        private IWebElement CheckOut => findElements.CssElement("#cart_contents_container > div > div.cart_footer > a.btn_action.checkout_button");
        private IWebElement FirstnameTxtBox => findElements.CssElement("#first-name");
        private IWebElement LastnameTxtBox => findElements.CssElement("#last-name");
        private IWebElement ZipcodeTxtBox => findElements.CssElement("#postal-code");
        private IWebElement ContinueBtn => findElements.CssElement("#checkout_info_container > div > form > div.checkout_buttons > input");
        private IWebElement PaymentInformation => findElements.CssElement("#checkout_summary_container > div > div.summary_info > div:nth-child(1)");
        private IWebElement ShippingInformation => findElements.CssElement("#checkout_summary_container > div > div.summary_info > div:nth-child(3)");
        private IWebElement FinishBtn => findElements.CssElement(".btn_action.cart_button");
        private IWebElement CancelBtn => findElements.CssElement(".cart_cancel_link.btn_secondary");
        private IWebElement ThankyouMessege => findElements.CssElement("#checkout_complete_container > h2");
        private IWebElement ImageThankYou => findElements.CssElement("#checkout_complete_container > img");
        private IWebElement DescriptionofProduct => findElements.CssElement(".inventory_item_desc");
        #endregion


        #region Page Actions

        public CartPage ClickCheckOut()
        {
            this.CheckOut.Click();
            return this;
        }
        public void Test() { }
        public CartPage FillInformation(string firstname, string lastname, string zipcode)
        {
            this.FirstnameTxtBox.SendKeys(firstname);
            this.LastnameTxtBox.SendKeys(lastname);
            this.ZipcodeTxtBox.SendKeys(zipcode);
            return this;
        }

        public string GetDescriptionOfProduct()
        {
            return this.DescriptionofProduct.Text;
        }

        public CartPage clickcountinue()
        {
            this.ContinueBtn.Click();
            return this;
        }
        public CartPage clickfinish()
        {
            
            this.FinishBtn.Click();
            return this;
        }
        public bool DisplayPaymentInfo()
        {
            try
            {
                return this.PaymentInformation.Displayed;
            }
            catch
            {
                return false;
            }
        }
        public bool DisplayShippingInfo()
        {
            try
            {
                return this.ShippingInformation.Displayed;
            }
            catch
            {
                return false;
            }
        }
        public bool DislayCancelBtn()
        {
            try
            {
                return this.CancelBtn.Displayed;
            }
            catch
            {
                return false;
            }
        }

        public bool Displayimagethankyou()
        {
            try
            {
                return this.ImageThankYou.Displayed;
            }
            catch
            {
                return false;
            }
        }

        #endregion

    

    }
}
