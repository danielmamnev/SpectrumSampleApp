using System;
using System.Collections.Generic;

namespace SpectrumSampleApp.Core.Models
{

    public class Pagination
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public int total { get; set; }
    }

    public class ArticleCollection
    {
        public Pagination pagination { get; set; }
        public List<Article> data { get; set; }

    }
}
