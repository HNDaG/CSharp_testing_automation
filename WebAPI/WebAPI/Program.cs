using System;
using System.Net.Http;
using Newtonsoft.Json;
using WebAPI.Helpers;
using WebAPI.DataModels;
using WebAPI.API;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace WebAPI
{
    internal class Program
    {

        static void Main(string[] args)
        {

            DropboxApi dropboxApi = new();

            /*dropboxApi.UploadFile("C:/Users/nikit/Desktop/WebAPI/WebAPI/CAT.jpg", "/CAT.jpg");
            dropboxApi.apiResponse.EnsureSuccessful();*/

            dropboxApi.GetFileMetadata("/Images/CAT.jpg");
            Metadata metadata = JsonConvert.DeserializeObject<Metadata>(dropboxApi.apiResponse.ContentAsString);
            metadata.Representation();
            dropboxApi.apiResponse.EnsureSuccessful();

            /*dropboxApi.DeleteFile("/CAT.jpg");
            dropboxApi.apiResponse.EnsureSuccessful();*/


        }
    }
}

