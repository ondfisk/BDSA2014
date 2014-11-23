using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Northwind.Wpf.Models
{
    public class WebEmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _client;

        public WebEmployeeRepository()
        {
            var baseAddress = new Uri("http://localhost:34739");
            _client = new HttpClient { BaseAddress = baseAddress };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Employee> Create(Employee employee)
        {
            var response = await _client.PostAsJsonAsync("api/employees", employee);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Employee>();
        }

        public IQueryable<Employee> Read()
        {
            var response = _client.GetAsync("api/employees").Result;

            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<IEnumerable<Employee>>().Result.AsQueryable();
        }

        public async Task<Employee> Read(int id)
        {
            var response = await _client.GetAsync("api/employees/" + id);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsAsync<Employee>();
        }

        public async Task<bool> Update(Employee employee)
        {
            var response = await _client.PutAsJsonAsync("api/employees", employee);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _client.DeleteAsync("api/employees/" + id);

            return response.IsSuccessStatusCode;
        }

        public void Dispose()
        {
            _client.Dispose();
        }
    }
}
