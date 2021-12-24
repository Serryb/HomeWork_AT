using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Interactions;

namespace HomeWork5
{
    class MenuPage : AbstractPage
    {
        public MenuPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement chkMenu;

        [FindsBy(How = How.XPath, Using = "//a[@href = '/Product']")]
        private IWebElement ProductsLnk;
        
        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'Logout')]")]
        private IWebElement logout;

        public string GetNamePage()
        {
            return chkMenu.Text;
        }

        public AllProductsPage GoToProducts()
        {
            IAction action = new Actions(driver)
                .Click(ProductsLnk);
            action.Perform();

            return new AllProductsPage(driver);
        }

        public void Logout()
        {
            IAction action = new Actions(driver).Click(logout);
            action.Perform();
        }
    }
}
