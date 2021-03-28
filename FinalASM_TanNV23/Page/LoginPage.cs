using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalASM_TanNV23.Page
{
    class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        { }        

        #region Page Elements

        private IWebElement Usertxtbox => findElements.CssElement("#user-name");
        private IWebElement Passwordtxtbox => findElements.CssElement("#password");
        private IWebElement LoginButton =>  findElements.CssElement("#login-button");
        private IWebElement Errormessage => findElements.CssElement("#login_button_container > div > form > h3");

        #endregion



        #region Page Actions

        public ShoppingPage LoginToPage(string user, string password)
        {

            this.Usertxtbox.SendKeys(user);
            this.Passwordtxtbox.SendKeys(password);
            this.LoginButton.Click();

            return new ShoppingPage(this.driver);
        }
        public bool LoginUnsccessfully()
        {
            try
            {
                return this.Errormessage.Displayed;
            }
            catch
            {
                return false;
            }        
        }

        #endregion

    }
}
