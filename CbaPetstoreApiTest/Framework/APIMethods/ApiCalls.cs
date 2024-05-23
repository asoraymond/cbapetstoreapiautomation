using Microsoft.CodeAnalysis;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CbaPetstoreApiTest.Framework.APIMethods
{
    public class ApiCalls: IApiCalls
    {
        public string _baseurl;
        public ApiCalls(string baseUrl) {
            _baseurl = baseUrl;
        }
        public async Task<RestResponse> GetMethodAsync(string endpoint)
        {
            endpoint = _baseurl + endpoint;
            var options = new RestClientOptions(endpoint)
            {
                ThrowOnAnyError = true
            };

            var client = new RestClient(options);

            var request = new RestRequest();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            var response = await client.GetAsync(request);
            return response;
        }

        public async Task<RestResponse> PostMethodAsync<T>(string endpoint, T body)
        {
            endpoint = _baseurl + endpoint;
            var options = new RestClientOptions(endpoint)
            {
                //ThrowOnAnyError = true
            };
            var client = new RestClient(options);

            var request = new RestRequest();
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("Content-Type", "application/json");
            request.AddBody(body);
            return await client.PostAsync(request);
        }

    }
}
