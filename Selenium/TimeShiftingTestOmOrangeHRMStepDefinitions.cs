using System;
using TechTalk.SpecFlow;
using Pages;

namespace Selenium
{
    [Binding]
    public class TimeShiftingTestOmOrangeHRMStepDefinitions
    {
        AddNewRecord addNewRecord = null;

        [Given(@"we have driver initialized")]
        public void GivenWeHaveDriverInitialized()
        {
            addNewRecord = new AddNewRecord();
            addNewRecord.start_Browser();
        }

        [When(@"we login successfully")]
        public void WhenWeLoginSuccessfully()
        {
            addNewRecord.login_Page(addNewRecord.driver);
        }

        [When(@"we go to time shift panel")]
        public void WhenWeGoToTimeShiftPanel()
        {
            addNewRecord.main_Page(addNewRecord.driver);
        }

        [When(@"we add new time shift")]
        public void WhenWeAddNewTimeShift()
        {
            addNewRecord.time_Shift_Page(addNewRecord.driver);
        }

        [Then(@"we have new time shift appeared")]
        public void ThenWeHaveNewTimeShiftAppeared()
        {
            addNewRecord.check_New_Row(addNewRecord.driver);
        }

        [Then(@"we remove row")]
        public void ThenWeRemoveRow()
        {
            addNewRecord.remove_Row_And_Check(addNewRecord.driver);
        }
    }
}
