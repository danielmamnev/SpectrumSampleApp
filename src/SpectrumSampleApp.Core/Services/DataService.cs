using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SpectrumSampleApp.Core.Interfaces;
using SpectrumSampleApp.Core.Models;

namespace SpectrumSampleApp.Core.Services
{
    public class DataService : IDataService
    {
        private readonly IRestService _restService;

        public DataService()
        {
            _restService = new RestService();
        }

        public async Task<ArticleCollection> GetAllNews(string query)
        {

            return await _restService.GetAsync<ArticleCollection>(query);



            //Debug mock data to avoid API limit
            //string jsonFileName = "MockNews.json";

            //var assembly = typeof(Core.App).Assembly;
            //Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            //using (var reader = new System.IO.StreamReader(stream))
            //{
            //    var jsonString = reader.ReadToEnd();
            //    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<ArticleCollection>(jsonString);
            //    return result;

        }

    }
}
