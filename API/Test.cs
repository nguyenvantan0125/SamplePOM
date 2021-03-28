using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace API
{
    public class Test : PageTest
    {
        [Fact]
        public void GetAllEmployees()
        {
            var response = client().Execute(request("/employees"));

            Console.WriteLine(response.Content);
            Assert.True(response.StatusCode == HttpStatusCode.OK);
            Assert.True(response.Request.Timeout < 1000);
            
        }
        [Fact]
        public void GetEmployeeWithId1()
        {
            var response = client().Execute(request("/employees/1"));

            Assert.True(response.StatusCode == HttpStatusCode.OK);
            Assert.True(response.Request.Timeout < 1000);

            var employeelist = JsonConvert.DeserializeObject<List<Datum>>(response.Content);
            Assert.Equal(1, employeelist[0].id);
            Assert.Equal("Successfully! Record has been fetched.", response.ErrorMessage);
            Assert.Equal(24, employeelist.Count);
        }
        [Fact]
        public void PostNewEmployee()
        {
            var request = new RestRequest("/create", Method.POST);
            var item = new Datum
            {
                id = 123,
                employee_name = "FA-TanNV23",
                employee_salary = 1000000000,
                employee_age = 10,
                profile_image = "N/A"
            };
            request.AddJsonBody(item);
            var response = client().Execute(request);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }
    
    }
}

