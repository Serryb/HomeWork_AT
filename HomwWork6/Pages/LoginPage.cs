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
    class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='Name']")]
        private IWebElement LoginName;

        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        private IWebElement LoginPassword;

        [FindsBy(How = How.XPath, Using = "//input[contains(@class,'btn')]")]
        private IWebElement LoginBtn;

        [FindsBy(How = How.XPath, Using = "//h2")]
        private IWebElement chkLogin;

        public void Login(String log, string pass)
        {
            IAction action = new Actions(driver)
                .Click(LoginName)
                .SendKeys(log)
                .Click(LoginPassword)
                .SendKeys(pass)
                .Click(LoginBtn);
            action.Perform();
        }

        public string GetNamePage()
        {
            return chkLogin.Text;
        }
    }
}
