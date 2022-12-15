using System;
using TechTalk.SpecFlow;
using Newtonsoft.Json;
using WebAPI.Helpers;
using WebAPI.DataModels;
using WebAPI.API;

namespace TestAPI.StepsDefinition
{
    [Binding]
    public class DropboxApiFileManagementStepDefinitions
    {
        public ApiResponse response;// Why ?
        public Metadata fileMetadata;//

        public string fileNameDbx = "";
        public string filePathDbx = "";

        public string metaName = "";



        [Given(@"I have a file in dropbox")]
        public void GivenIHaveAFileInDropbox()
        {
            fileNameDbx += "CAT.jpg";
            filePathDbx += "Images/";
            filePathDbx += fileNameDbx;
        }

        [When(@"I send request to get file metadata")]
        public void WhenISendRequestToGetFileMetadata()
        {
            var responseMetadata = new DropboxApi().GetFileMetadata(filePathDbx);
            responseMetadata.EnsureSuccessful();
            metaName += (JsonConvert.DeserializeObject<Metadata>(responseMetadata.ContentAsString)).Name; ///?

        }

        [Then(@"I should see my file metadata")]
        public void ThenIShouldSeeMyFileMetadata()
        {
            Assert.AreEqual(fileNameDbx, metaName); /// ?
        }


        [When(@"I send request to delete file")]
        public void WhenISendRequestToDeleteFile()
        {
        }

        [Then(@"I should not see my file")]
        public void ThenIShouldNotSeeMyFile()
        {
        }

        [Given(@"I have a file to upload")]
        public void GivenIHaveAFileToUpload()
        {
        }

        [When(@"I send request to upload file")]
        public void WhenISendRequestToUploadFile()
        {
        }

        [Then(@"I should see my file uploaded")]
        public void ThenIShouldSeeMyFileUploaded()
        {
        }
    }
}
