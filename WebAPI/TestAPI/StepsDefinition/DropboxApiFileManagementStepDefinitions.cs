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
        public DropboxApi dropboxApi = new DropboxApi();

        public string fileNameDbx = "";
        public string filePathDbx = "";

        public string metaName = "";


        [Given(@"I have a file in dropbox")]
        public void GivenIHaveAFileInDropbox()
        {
            fileNameDbx += "CAT.jpg";
            filePathDbx += "/Images/";
            filePathDbx += fileNameDbx;
        }

        [When(@"I send request to get file metadata")]
        public void WhenISendRequestToGetFileMetadata()
        {
            dropboxApi.GetFileMetadata(filePathDbx);
            
        }

        [Then(@"I should see my file metadata")]
        public void ThenIShouldSeeMyFileMetadata()
        {
            dropboxApi.apiResponse.EnsureSuccessful();
        }


        [When(@"I send request to delete file")]
        public void WhenISendRequestToDeleteFile()
        {
            dropboxApi.DeleteFile(filePathDbx);
        }

        [Then(@"I should not see my file")]
        public void ThenIShouldNotSeeMyFile()
        {
            dropboxApi.apiResponse.EnsureSuccessful();
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
