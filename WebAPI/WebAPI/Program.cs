using System;
using System.Net.Http;
using Newtonsoft.Json;
using WebAPI.Helpers;
using WebAPI.DataModels;
using WebAPI.API;
using Newtonsoft.Json.Linq;

namespace WebAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var responseData = new DropboxApi().GetFileMetadata("/Images/CAT.jpg");
            Metadata metadata = JsonConvert.DeserializeObject<Metadata>(responseData.ContentAsString);
            metadata.Representation();

            var response = new DropboxApi().DeleteFile("/Images/CAT1.jpg");
        }
    }
}
