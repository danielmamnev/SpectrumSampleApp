using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpectrumSampleApp.Core.Services
{
    public class RestService : IRestService
    {
        //free api does not allow for https request
        public string baseURL => $"http://api.mediastack.com/v1/news?access_key=d0fd0bb43d480aefb4b8ab2704fa70fd";
        HttpClient client;

        public RestService()
        {
            client = new HttpClient();
        }

        public async Task<T> GetAsync<T>(string query)
        {
            //For the sake of the sample -  we will return US based stories in English by default
            query += "&date=2022-09-27";
            query += "&countries=us";
            query += "&languages=en";

            string uri = baseURL + query;
            Console.WriteLine(uri);
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            throw new Exception();
        }
    }

    public interface IRestService
    {
        Task<T> GetAsync<T>(string query);
    }
}
