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
    class CreateProductPage : AbstractPage
    {
        public CreateProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='ProductName']")]
        private IWebElement ProductName;

        [FindsBy(How = How.XPath, Using = "//*[@id='CategoryId']")]
        private IWebElement CategoryId;

        [FindsBy(How = How.XPath, Using = "//*[@id='SupplierId']")]
        private IWebElement SupplierId;

        [FindsBy(How = How.XPath, Using = "//*[@id='UnitPrice']")]
        private IWebElement UnitPrice;

        [FindsBy(How = How.XPath, Using = "//*[@id='QuantityPerUnit']")]
        private IWebElement QuantityPerUnit;

        [FindsBy(How = How.XPath, Using = "//*[@id='UnitsInStock']")]
        private IWebElement UnitsInStock;

        [FindsBy(How = How.XPath, Using = "//*[@id='UnitsOnOrder']")]
        private IWebElement UnitsOnOrder;

        [FindsBy(How = How.XPath, Using = "//*[@id='ReorderLevel']")]
        private IWebElement ReorderLevel;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'btn')]")]
        private IWebElement SendBtn;

        public void Create(string Name, string CatId, string SupId, string UP, string QPerU, string UInS, string UOnO, string RLevel)
        {
            new SelectElement(CategoryId).SelectByText(CatId);
            new SelectElement(SupplierId).SelectByText(SupId);
            IAction action = new Actions(driver)
                .Click(ProductName)
                .SendKeys(Name)
                .Click(UnitPrice)
                .SendKeys(UP)
                .Click(QuantityPerUnit)
                .SendKeys(QPerU)
                .Click(UnitsInStock)
                .SendKeys(UInS)
                .Click(UnitsOnOrder)
                .SendKeys(UOnO)
                .Click(ReorderLevel)
                .SendKeys(RLevel)
                .Click(SendBtn);
            action.Perform();
        }
    }
}
