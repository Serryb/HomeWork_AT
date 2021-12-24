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

namespace HomeWork6
{
    class AllProductsPage : AbstractPage
    {
        public AllProductsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(@class,'btn')]")]
        private IWebElement NewProductBtn;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Test')]")]
        private IWebElement Product;

        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement chkPage;

        [FindsBy(How = How.XPath, Using = "(//*[@data-remove])[78]")]
        private IWebElement remove;

        public string GetNamePage()
        {
            return chkPage.Text;
        }

        public ProductLogic AddNewProduct()
        {
            IAction action = new Actions(driver)
                .Click(NewProductBtn);
            action.Perform();

            return new ProductLogic(driver);
        }

        public EditProductPage ViewProduct()
        {
            IAction action = new Actions(driver)
                .Click(Product);
            action.Perform();
            return new EditProductPage(driver);
        }

        public void Remove()
        {
            IAction action = new Actions(driver).Click(remove);
            action.Perform();
            driver.SwitchTo().Alert().Accept();
        }
    }
}
