using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reset_Api
{
    public class Response
    {
        public void getemp(string name)
        {
            RestClient restClient = new RestClient("http://localhost:4000");
            RestRequest restRequest = new RestRequest("/emp", Method.GET);
            var response = restClient.Execute(restRequest);
            Console.WriteLine("Response :" + response.Content);
        }

        public void Delete(int id)
        {
            RestClient restClient = new RestClient("http://localhost:4000");
            RestRequest restRequest = new RestRequest("/emp", Method.DELETE);
            var response = restClient.Execute(restRequest);
            Console.WriteLine("Response :" + response.Content);
        }

        public void Add(Emp emp)
        {
            RestClient restClient = new RestClient("http://localhost:4000");
            RestRequest restRequest = new RestRequest("/emp", Method.POST);
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(emp), ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);
            Console.WriteLine("Response :" + response.Content);
        }
        public void Update(Emp emp, int id)
        {
            RestClient restClient = new RestClient("http://localhost:4000");
            RestRequest restRequest = new RestRequest("/emp", Method.PUT);
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(emp), ParameterType.RequestBody);
            var response = restClient.Execute(restRequest);
            Console.WriteLine("Response :" + response.Content); 
        }
    }
}