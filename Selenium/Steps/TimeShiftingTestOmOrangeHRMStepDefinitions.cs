using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using Pages;
using Selenium.Hooks;

namespace Selenium.Steps
{
    [Binding]
    public class TimeShiftingTestOmOrangeHRMStepDefinitions
    {
        public ChromeDriver driver = null;
        public Login login = null;
        public MainPage mainPage = null;
        public TimeShiftPage timeShiftPage = null;
        private Driver hooks = new Driver();

        [Given(@"we have logged in the site")]
        public void GivenWeHaveLoggenInTheSite()
        {
            login = new Login(driver);
            login.LoginPage();
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

        [When(@"we remove row")]
        public void WhenWeRemoveRow()
        {
            timeShiftPage.RemoveRow();
        }

        [Then(@"we have row removed")]
        public void ThenWeHaveRowRemoved()
        {
            timeShiftPage.CheckRemovedRow();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = hooks.StartBrowser();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            hooks.Quit(driver);
        }
    }
}
