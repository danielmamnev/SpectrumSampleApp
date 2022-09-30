using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SpectrumSampleApp.Core.Models;

namespace SpectrumSampleApp.Core.Interfaces
{
    public interface IDataService
    {
        Task<ArticleCollection> GetAllNews(string query);
    }
}
