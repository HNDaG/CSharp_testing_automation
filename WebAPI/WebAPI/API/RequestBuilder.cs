using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using WebAPI.Helpers;
using WebAPI.Extensions;
using Newtonsoft.Json;
using WebAPI.DataModels;

namespace WebAPI.API
{
    public class RequestBuilder
    {

        public HttpRequestMessage _request;
        private readonly HttpClient _httpClient;
        private static Uri BaseServiceUri { get; set; }

        public RequestBuilder(string url, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _request = new HttpRequestMessage();
            BaseServiceUri = new Uri(url);


            WithHeader("Authorization", ConfigurationHelper.AuthorizationToken);
        }

        public RequestBuilder WithHeaders(Dictionary<string, string> headers)
        {
            foreach (var header in headers)
            {
                _request.Headers.Add(header.Key, header.Value);
            }

            return this;
        }

        public RequestBuilder Uri(string url)
        {
            _request.RequestUri = BaseServiceUri.Append(url);
            return this;
        }

        public RequestBuilder Method(HttpMethod method)
        {
            _request.Method = method;
            return this;
        }

        public RequestBuilder WithHeader(string key, string value)
        {
            _request.Headers.Add(key, value);
            return this;
        }

        public RequestBuilder WithBody(string requestBody)
        {
            _request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
            return this;
        }

        public RequestBuilder WithFile(string localFilePath, string uploadPath)
        {
            byte[] fileData = File.ReadAllBytes(localFilePath);

            UploadFile uploadFile = new UploadFile();
            uploadFile.AutoRename = true;
            uploadFile.Mode = "add";
            uploadFile.Mute = false;
            uploadFile.Path = uploadPath;

            _request.Content = new StreamContent(new MemoryStream(fileData));
            _request.Content.Headers.Add("Content-Type", "application/octet-stream");
            _request.Content.Headers.Add("Dropbox-API-Arg", JsonConvert.SerializeObject(uploadFile));
            return this;
        }

        public ApiResponse Execute()
        {
                _request.Headers.Referrer = _request.RequestUri;
                var response = _httpClient.SendAsync(_request, CancellationToken.None).Result;
                return new ApiResponse(response);
        }
    }
}
