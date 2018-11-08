using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace BiddingSystem.Specs.ApiClient
{
    public class MyRestClient
    {
        private HttpClient HttpClient { get; }

        private HttpRequestMessage CreateRequest(string url, HttpMethod method)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(new Uri("https://bidding.com"),url)
            };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Method = method;
            return request;
        }

        private HttpResponseMessage SendRequest(HttpRequestMessage request)
        {
            var task = HttpClient.SendAsync(request);
            return (LastResponse = task.Result);
        }


        public MyRestClient(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpResponseMessage LastResponse { get; private set; }

        public HttpResponseMessage SendRequest(string url, HttpMethod method)
        {
            var request = CreateRequest(url, method);
            return SendRequest(request);
        }


        public HttpResponseMessage SendRequest<T>(string url, HttpMethod method, T content) where T : class
        {
            HttpRequestMessage request = CreateRequest(url, method);
            request.Content = new ObjectContent<T>(content, new JsonMediaTypeFormatter());
            return SendRequest(request);
        }
    }
}