using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace API
{
    public class PageTest
    {
        string baseUrl = "http://dummy.restapiexample.com/api/v1";
        public RestClient client() => new RestClient(baseUrl);
        public RestRequest Path(string path)
        {
            switch (path)
            {
                case "/employees":
                    return  new RestRequest(path, Method.GET);                
                case "/create":
                    return new RestRequest(path, Method.POST);
                default:
                    return new RestRequest(path, Method.GET);
            }
        }
        public RestRequest request(string getPath) => Path(getPath);
    }
}
