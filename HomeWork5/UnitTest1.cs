using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumExtras.PageObjects;
using System;

namespace HomeWork5
{
    public class Tests
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://localhost:5000";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login("user", "user");
            Assert.AreNotEqual(loginPage.GetNamePage(), "Login");
        }

        [Test]
        public void AddProduct()
        {
            MenuPage menuPage = new MenuPage(driver);
            AllProductsPage productsPage = menuPage.GoToProducts();
            ProductLogic productPage = productsPage.AddNewProduct();

            Product newProduct = ProductGenerator.GenerateProduct();
            productPage.CreateNewProduct(newProduct);

            Assert.AreEqual(productsPage.GetNamePage(), "All Products");
        }
        [Test]
        public void CheckProduct()
        {
            MenuPage menuPage = new MenuPage(driver);
            AllProductsPage productsPage = menuPage.GoToProducts();
            EditProductPage product = productsPage.ViewProduct();
            product.Check();
        }

        [Test]
        public void RemoveProduct()
        {
            MenuPage menuPage = new MenuPage(driver);
            AllProductsPage productsPage = menuPage.GoToProducts();
            productsPage.Remove();
        }

        [TearDown]
        public void TearDown()
        {
            MenuPage menuPage = new MenuPage(driver);
            menuPage.Logout();
            driver.Quit();
        }
    }
}