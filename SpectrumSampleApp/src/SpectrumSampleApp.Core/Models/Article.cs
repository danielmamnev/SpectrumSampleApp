using System;
namespace SpectrumSampleApp.Core.Models
{
    public class Article
    {
        public string? author { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? url { get; set; }
        public string? source { get; set; }
        public string? image { get; set; }
        public string? category { get; set; }
        public string? language { get; set; }
        public string? country { get; set; }
        public DateTime? published_at { get; set; }

        public string ImageURL
        {
            get
            {
                if (image != null)
                    return image;
                else
                    return "https://media.istockphoto.com/photos/global-earth-rotating-digital-world-news-studio-background-for-news-picture-id978149622?s=612x612";

            }
        }
    }
}
