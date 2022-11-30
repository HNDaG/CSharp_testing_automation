using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Pages
{
    [TestFixture]
    public class AddNewRecord
    {
        string url = "https://opensource-demo.orangehrmlive.com/";
        string username = "Admin";
        string password = "admin123";
        string shiftName = "Afternoon";
        string assignedEmployees = "Odis Adalwin";

        public ChromeDriver driver;
        public WebDriverWait wait;



        public void start_Browser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = url;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public IWebElement usernameLogin => driver.FindElement(By.CssSelector("[name = 'username']"));
        public IWebElement passwordLogin => driver.FindElement(By.CssSelector("[name = 'password']"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//*[@id='app']/div[1]/div/div[1]/div/div[2]/div[2]/form/div[3]/button"));

        public void login_Page(ChromeDriver driver)
        {
            wait.Until(d => usernameLogin);

            usernameLogin.SendKeys(username);
            passwordLogin.SendKeys(password);

            loginButton.Click();
        }


        public IWebElement adminPage => driver.FindElement(By.LinkText("Admin"));
        public IWebElement dDownJobs => driver.FindElement(By.XPath("/html/body/div/div[1]/div[1]/header/div[2]/nav/ul/li[2]/span"));
        public IWebElement workShifts => driver.FindElement(By.XPath("/html/body/div/div[1]/div[1]/header/div[2]/nav/ul/li[2]/ul/li[5]/a"));
        public IWebElement addButton => driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/div[1]/div/button"));

        public void main_Page(ChromeDriver driver)
        {
            wait.Until(d => adminPage);
            adminPage.Click();

            wait.Until(d => dDownJobs);
            dDownJobs.Click();

            wait.Until(d => workShifts);
            workShifts.Click();

            wait.Until(d => addButton);
            addButton.Click();

        }



        public void time_Shift_Page(ChromeDriver driver)
        {
            wait.Until(d => driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div/div/div[2]/input")));
            driver.FindElement(By.XPath("/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div/div/div[2]/input")).SendKeys(shiftName);

            //From part
            string clockTimeInput0 = "/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/div/div/i";
            string clockTimeInput1 = "/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/div/div/i";
            string xPathButtonFrom = "/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/div/div[2]/div[1]/i[2]";
            string xPathButtonTo = "/html/body/div/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/div/div[2]/div[1]/i[1]";
            string inputAssignedEmployees = "//input[@placeholder='Type for hints...']";
            string saveButton = "//button[@type='submit']";

            driver.FindElement(By.XPath(clockTimeInput0)).Click();
            wait.Until(d => driver.FindElement(By.XPath(xPathButtonFrom)));
            for (int i = 0; i < 3; i++)
            {
                driver.FindElement(By.XPath(xPathButtonFrom)).Click();
            }

            driver.FindElement(By.XPath(clockTimeInput1)).Click();
            wait.Until(d => driver.FindElement(By.XPath(xPathButtonTo)));

            for (int i = 0; i < 1; i++)
            {
                driver.FindElement(By.XPath(xPathButtonTo)).Click();
            }

            driver.FindElement(By.XPath(inputAssignedEmployees)).SendKeys(assignedEmployees);

            driver.FindElement(By.XPath(saveButton)).Click();
        }

        public void check_New_Row(ChromeDriver driver)
        {
            string xPathFoundRow = $"//div[@class='oxd-table-row oxd-table-row--with-border' and contains(., '{shiftName}')]";

            wait.Until(d => driver.FindElement(By.XPath(xPathFoundRow)));
            IWebElement foundRow = driver.FindElement(By.XPath(xPathFoundRow));

            foundRow.FindElement(By.XPath($"//div[contains(., '{shiftName}')]"));
            foundRow.FindElement(By.XPath($"//div[contains(., '06:00')]"));
            foundRow.FindElement(By.XPath($"//div[contains(., '18:00')]"));
            foundRow.FindElement(By.XPath($"//div[contains(., '12.00')]"));

        }

        public void remove_Row_And_Check(ChromeDriver driver)
        {

            string xPathDelete = $"//div[@class='oxd-table-row oxd-table-row--with-border' and contains(., '{shiftName}')]//i[@class='oxd-icon bi-trash']";

            wait.Until(d => driver.FindElement(By.XPath(xPathDelete)));
            IWebElement foundRow = driver.FindElement(By.XPath(xPathDelete));

            wait.Until(d => foundRow.FindElement(By.XPath("//button[@class='oxd-icon-button oxd-table-cell-action-space']")));
            foundRow.FindElement(By.XPath("//button[@class='oxd-icon-button oxd-table-cell-action-space']")).Click();
            wait.Until(d => driver.FindElement(By.XPath("//button[contains(.,'Yes, Delete')]"))).Click();

            if (driver.FindElements(By.XPath(xPathDelete)).Count > 0)
            {
                Assert.Fail();
            }
        }
    }
}
