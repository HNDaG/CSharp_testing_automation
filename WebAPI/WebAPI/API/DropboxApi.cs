using System;
using System.Net.Http;
using Newtonsoft.Json;
using WebAPI.Helpers;
using WebAPI.DataModels;
using System.IO;

namespace WebAPI.API
{
    public class DropboxApi
    {
        private readonly HttpClient _httpClient;
        public ApiResponse apiResponse;

        public DropboxApi()
        {
            _httpClient = new HttpClient();
        }

        public ApiResponse GetFilesList()
        {
            RequestBuilder request = new RequestBuilder(ConfigurationHelper.ServiceUrl, _httpClient);

            const string url = "files/list_folder";
            var requestBody = JsonConvert.SerializeObject(new Base());

            apiResponse = request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
            return apiResponse;
        }

        public ApiResponse DeleteFile(string file_path)
        {
            RequestBuilder request = new RequestBuilder(ConfigurationHelper.ServiceUrl, _httpClient);

            Base path = new Base();
            path.Path = file_path;

            const string url = "files/delete_v2";
            var requestBody = JsonConvert.SerializeObject(path);

            apiResponse = request.Uri(url).Method(HttpMethod.Post).WithBody(requestBody).Execute();
            return apiResponse;
        }

        public ApiResponse GetFileMetadata(string file_path)
        {
            RequestBuilder request = new RequestBuilder(ConfigurationHelper.ServiceUrl, _httpClient);

            Base path = new Base();
            path.Path = file_path;

            string url = "files/get_metadata";
            var requestBody = JsonConvert.SerializeObject(path);

            apiResponse = request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
            return apiResponse;
        }

        public ApiResponse UploadFile(string localFilePath, string uploadPath)
        {
            RequestBuilder request = new RequestBuilder(ConfigurationHelper.ServiceUrl, _httpClient);

            string url = "files/upload";


            apiResponse = request.Method(HttpMethod.Post).Uri(url).WithFile(localFilePath, uploadPath).Execute();
            return apiResponse;
        }

    }
}
