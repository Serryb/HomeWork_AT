using System;
using TechTalk.SpecFlow;

namespace HomeWork6
{
    [Binding]
    public class AddStepDefinitions
    {
        private IWebDriver driver;

        [Given(@"Loggin")]
        public void Logging()
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

        [When(@"I add product")]
        public void IGoToProductsPageAndAddProduct()
        {
            MenuPage menuPage = new MenuPage(driver);
            AllProductsPage productsPage = menuPage.GoToProducts();
            ProductLogic productPage = productsPage.AddNewProduct();

            Product newProduct = ProductGenerator.GenerateProduct();
            productPage.CreateNewProduct(newProduct);
        }

        [Then(@"Ok")]
        public void Ok()
        {
            Assert.AreEqual(driver.FindElement(By.XPath("//h2")).Text, "All Products");
            driver.Quit();
        }
    }
}
