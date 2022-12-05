using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using Pages;

namespace Selenium.Steps
{
    [Binding]
    public class TimeShiftingTestOmOrangeHRMStepDefinitions
    {
        public ChromeDriver driver = null;
        public Login login = null;
        public MainPage mainPage = null;
        public TimeShiftPage timeShiftPage = null;

        [Given(@"we have logged in the site")]
        public void GivenWeHaveLoggenInTheSite()
        {
            login = new Login();
            driver = login.StartBrowser();
            login.LoginPage(driver);
        }

        [When(@"we go to time shift panel")]
        public void WhenWeGoToTimeShiftPanel()
        {
            mainPage = new MainPage(driver);
            mainPage.GoToShiftPage();
        }

        [When(@"we add new time shift")]
        public void WhenWeAddNewTimeShift()
        {
            timeShiftPage = new TimeShiftPage(driver);
            timeShiftPage.ShiftTimeTo6To6();
        }

        [Then(@"we have new time shift appeared")]
        public void ThenWeHaveNewTimeShiftAppeared()
        {
            timeShiftPage.CheckNewRow();
        }

        [Then(@"we remove row")]
        public void ThenWeRemoveRow()
        {
            timeShiftPage.RemoveRowAndCheck();
        }
    }
}
