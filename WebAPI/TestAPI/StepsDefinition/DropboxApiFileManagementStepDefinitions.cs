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

        public string fileNameDbx = "CAT.jpg";
        public string filePathDbx = "/Images/";

        public string localFilePath = "C:/Users/nikit/Desktop/WebAPI/WebAPI/CAT.jpg";

        public string fileID = "";

        [When(@"I send request to upload file")]
        public void WhenISendRequestToUploadFile()
        {
            dropboxApi.UploadFile(localFilePath, filePathDbx + fileNameDbx);
        }

        [Then(@"I should see my file uploaded")]
        public void ThenIShouldSeeMyFileUploaded()
        {
            dropboxApi.apiResponse.EnsureSuccessful();
            fileID = dropboxApi.apiResponse.Content<FileResponse>().Id;
        }

        [When(@"I send request to get file metadata")]
        public void WhenISendRequestToGetFileMetadata()
        {
            dropboxApi.GetFileMetadata(filePathDbx+fileNameDbx);
            
        }

        [Then(@"I should see my file metadata")]
        public void ThenIShouldSeeMyFileMetadata()
        {
            dropboxApi.apiResponse.EnsureSuccessful();
            //Assert.That(fileID, Is.EqualTo(dropboxApi.apiResponse.Content<Metadata>().Id));
        }


        [When(@"I send request to delete file")]
        public void WhenISendRequestToDeleteFile()
        {
            dropboxApi.DeleteFile(filePathDbx+fileNameDbx);
        }

        [Then(@"I should not see my file")]
        public void ThenIShouldNotSeeMyFile()
        {
            dropboxApi.apiResponse.EnsureSuccessful();
           
        }

    }
}
