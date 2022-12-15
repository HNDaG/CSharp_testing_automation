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
        public RequestBuilder request;
        public DropboxApi()
        {
            request = new RequestBuilder(ConfigurationHelper.ServiceUrl);
        }

        public ApiResponse GetFilesList()
        {
            const string url = "files/list_folder";
            var requestBody = JsonConvert.SerializeObject(new Base());
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponse DeleteFile(string file_path)
        {
            Base path = new Base();
            path.Path = file_path;

            const string url = "files/delete_v2";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Uri(url).Method(HttpMethod.Post).WithBody(requestBody).Execute();
        }

        public ApiResponse GetFileMetadata(string file_path)
        {
            Base path = new Base();
            path.Path = file_path;

            string url = "files/get_metadata";
            var requestBody = JsonConvert.SerializeObject(path);
            return request.Method(HttpMethod.Post).Uri(url).WithBody(requestBody).Execute();
        }

        public ApiResponse UploadFile(string file_path, string upload_path)
        {
            Base path = new Base();
            path.Path = upload_path;
            string fileName = Path.GetFileName(file_path);

            string url = "files/upload";
            var requestBody = JsonConvert.SerializeObject(path);
            byte[] byteArray = File.ReadAllBytes(file_path);
            Base uploadPath = new Base();
            uploadPath.Path = upload_path;
            

            Console.WriteLine(request.Method(HttpMethod.Post).Uri(url).WithFile(byteArray)._request.ToString());

            return request.Method(HttpMethod.Post).Uri(url).WithFile(byteArray).Execute();
        }

    }
}
