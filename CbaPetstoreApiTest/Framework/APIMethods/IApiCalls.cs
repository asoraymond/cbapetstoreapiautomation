using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CbaPetstoreApiTest.Framework.APIMethods
{
    public interface IApiCalls
    {
        Task<RestResponse> GetMethodAsync(string url);
        Task<RestResponse> PostMethodAsync<T>(string url, T body);
    }
}
