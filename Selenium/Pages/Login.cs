using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Pages
{
    [TestFixture]
    public class Login
    {
        string url = "https://opensource-demo.orangehrmlive.com/";
        string username = "Admin";
        string password = "admin123";

        public ChromeDriver driver;
        public WebDriverWait wait;

        public IWebElement usernameLogin => driver.FindElement(By.CssSelector("[name = 'username']"));
        public IWebElement passwordLogin => driver.FindElement(By.CssSelector("[name = 'password']"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//button[@type='submit']"));

        public ChromeDriver StartBrowser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = url;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return driver;
        }


        public void LoginPage(ChromeDriver driver)
        {
            
            wait.Until(d => usernameLogin);

            usernameLogin.SendKeys(username);
            passwordLogin.SendKeys(password);

            loginButton.Click();
        }
    }
}
