using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace HomeWork3
{
    public class TestCases
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public bool IsElementNotPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
            }
            catch (NoSuchElementException)
            {
                return true;
            }
            return false;
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://localhost:5000";

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(1));
            wait.Timeout = TimeSpan.FromSeconds(1);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
           
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='Name']"))).SendKeys("user");
            
            driver.FindElement(By.XPath("//*[@id='Password']")).SendKeys("user");
            driver.FindElement(By.XPath("//input[contains(@class,'btn')]")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "Home page");
        }

        [Test]
        public void AddProduct()
        {
            driver.FindElement(By.XPath("//a[@href = '/Product']")).Click();
            driver.FindElement(By.XPath("//a[contains(@class,'btn')]")).Click();

            driver.FindElement(By.XPath("//*[@id='ProductName']")).SendKeys("Test");
            new SelectElement(driver.FindElement(By.XPath("//*[@id='CategoryId']"))).SelectByText("Baverages");
            new SelectElement(driver.FindElement(By.XPath("//*[@id='SupplierId']"))).SelectByText("Tokyo Traders");
            driver.FindElement(By.XPath("//*[@id='UnitPrice']")).SendKeys("100");
            driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).SendKeys("1");
            driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).SendKeys("2");
            driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).SendKeys("3");
            driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).SendKeys("4");

            driver.FindElement(By.XPath("//input[contains(@class,'btn')]")).Click();

            Assert.IsTrue(IsElementNotPresent(By.XPath("//*[h2='Product editing']")));
        }

        [Test]
        public void CheckProduct()
        {
            driver.FindElement(By.XPath("//a[@href = '/Product']")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Test')]")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='ProductName']")).GetAttribute("value"), "Test");
            Assert.AreEqual(driver.FindElement(By.XPath("//option[@selected='selected'][contains(text(),'Baverages')]")).Text, "Baverages");
            Assert.AreEqual(driver.FindElement(By.XPath("//option[@selected='selected'][contains(text(),'Tokyo Traders')]")).Text, "Tokyo Traders");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='UnitPrice']")).GetAttribute("value"), "100,0000");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).GetAttribute("value"), "1");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).GetAttribute("value"), "2");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).GetAttribute("value"), "3");
            Assert.AreEqual(driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).GetAttribute("value"), "4");            
        }

        [Test]
        public void RemoveProduct()
        {
            driver.FindElement(By.XPath("//a[@href = '/Product']")).Click();
            driver.FindElement(By.XPath("(//*[@data-remove])[78]")).Click();

            driver.SwitchTo().Alert().Accept();
        }

        [TearDown]
        public void TearDown()
        {
            driver.FindElement(By.XPath("//a[contains(@href,'Logout')]")).Click();

            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "Login");
            driver.Close();
            driver.Quit();
        }
    }
}