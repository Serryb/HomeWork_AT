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
using NUnit.Framework;

namespace HomeWork4.Pages
{
     class EditProductPage : AbstractPage
     {
        public EditProductPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='ProductName']")]
        private IWebElement ProductName;

        [FindsBy(How = How.XPath, Using = "//option[@selected='selected'][contains(text(),'Baverages')]")]
        private IWebElement CategoryId;

        [FindsBy(How = How.XPath, Using = "//option[@selected='selected'][contains(text(),'Tokyo Traders')]")]
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

        public void Check()
        {
            Assert.AreEqual(ProductName.GetAttribute("value"), "Test");
            Assert.AreEqual(CategoryId.Text, "Baverages");
            Assert.AreEqual(SupplierId.Text, "Tokyo Traders");
            Assert.AreEqual(UnitPrice.GetAttribute("value"), "100,0000");
            Assert.AreEqual(QuantityPerUnit.GetAttribute("value"), "1");
            Assert.AreEqual(UnitsInStock.GetAttribute("value"), "2");
            Assert.AreEqual(UnitsOnOrder.GetAttribute("value"), "3");
            Assert.AreEqual(ReorderLevel.GetAttribute("value"), "4");
        }
    }
}
