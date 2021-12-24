using System;
using TechTalk.SpecFlow;

namespace HomeWork6
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;

        [Given(@"I open url")]
        public void GivenIOpenUrl(string p0)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(p0);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        [When(@"I write login and password")]
        public void WhenIWriteLoginAndPassword(string user, string user1)
        {
            LoginPage loginPage = new LoginPage(driver);
            loginPage.Login(user, user1);
        }

        [Then(@"I connect to NorthWind")]
        public void ThenIConnectToNorthWind()
        {
            LoginPage loginPage = new LoginPage(driver);
            Assert.AreNotEqual(loginPage.GetNamePage(), "Login");
            driver.Close();
        }
        
    }
}
