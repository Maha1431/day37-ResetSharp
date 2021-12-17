using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reset_Api;
using RestSharp;
using System.Net;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace RestSharp_Test
{
    public class Emp
     {
        public int id { get; set; }
        public string name { get; set; }
        public int Salary { get; set; }
    }
        
    [TestClass]
    public class UnitTest1
    {
        RestClient client;
        [TestInitialize]
        public void Setup()
        {
            client = new RestClient("http://localhost/3000/emp");
        }

        private IRestResponse getEmpList()
        {
            //Arrange
            RestRequest request = new RestRequest("/emp", Method.GET);

            //Act
            IRestResponse response = client.Execute(request);
            return response;
        }

        [TestMethod]
        public void oncallingList_ReturnEmpList()
        {
            IRestResponse response = getEmpList();
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
            List<Emp> dataResponse = JsonConvert.DeserializeObject<List<Emp>>(response.Content);
            Assert.AreEqual(6, dataResponse.Count);

            foreach(Emp e in dataResponse)
            {
                System.Console.WriteLine("id:" + e.id + ",Name:" + e.name + " , Salary:" + e.Salary);
            }
        }
        [TestMethod]
         public void GivenEmp_OnPost_ShouldReturnaddEmp()
        {
            //Arrange
            RestRequest request = new RestRequest("/emp", Method.POST);
            JObject jObjectbody = new JObject();
            jObjectbody.Add("name", "ramu");
            jObjectbody.Add("Salary", 11000);

            request.AddParameter("application/json", jObjectbody, ParameterType.RequestBody);

            //Act
            IRestResponse response = client.Execute(request);
            //Assert
            Assert.AreEqual(response.StatusCode, HttpStatusCode.Created);
            Emp dataResponse = JsonConvert.DeserializeObject<Emp>(response.Content);
            Assert.AreEqual("ramu", dataResponse.name);
            Assert.AreEqual(11000, dataResponse.Salary);
            System.Console.WriteLine(response.Content);
        }
    }
}
