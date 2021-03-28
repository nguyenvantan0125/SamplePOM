using Core.DriverCore;
using Core.Helper;
using FinalASM_TanNV23.Page;
using Xunit;

namespace FinalASM_TanNV23.Test
{
    public class OrderByGoogle : BaseTest
    {
        //private BaseTest basestest => new BaseTest("Google");
        public OrderByGoogle()
        {
            GetBrowser("Google");
        }

        [Theory]
        [ParseJsonDictionary(@"..\..\..\..\Core\DataTest\Config.json", "PositiveUsers")]
        public void TestPositiveUsers(string account, string password, string name, string lastname, string zip)
        {           
            LoginPage loginPage = new LoginPage(Driver);
            var shopping = loginPage.LoginToPage(account, password).ClickAddToCart();
            Assert.True(shopping.CounterProduct(), " Number of product not match chosen");
            Assert.True(shopping.IsDisplayShoppingPage(), "Can not nagetive to Shopping page");
            string description = shopping.GetDescriptionProduct();

            var cartpage = shopping.NavigateCart().ClickCheckOut().FillInformation(name, lastname, zip).clickcountinue();

            // Verify the Payment Information, Shipping Information should be there.
            Assert.True(cartpage.DisplayPaymentInfo(), "The Payment not displayed");
            Assert.True(cartpage.DisplayShippingInfo(), "The Shipping Infor not displayed");
            Assert.True(cartpage.DislayCancelBtn(), "The Cancel button not displayed");

            // Verify DESCRIPTION of product should matched as the description on inventory page  
            Assert.True(cartpage.GetDescriptionOfProduct().Equals(description), " DESCRIPTION of product not match as the description on inventory page" );

            cartpage.clickfinish(); // click for finish            
            Assert.True(cartpage.Displayimagethankyou(), "The Image not displayed");            
            
        }

        [Theory]
        [ParseJsonDictionary(@"..\..\..\..\Core\DataTest\Config.json", "NegativeUsers")]
        public void TestNegativeUsers(string account, string password)
        {           
            LoginPage loginPage = new LoginPage(Driver);
            var shopping = loginPage.LoginToPage(account, password);

            // check locked user login 
            Assert.True(loginPage.LoginUnsccessfully(), "Locked user can log in to shopping page");                      
        }
    }
}
