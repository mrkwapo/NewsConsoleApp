using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BusinessNewsApp
{
    class Program
    {
        HttpClient client = new HttpClient();
        public static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.GetArticles();
        }

        private async Task GetArticles()
        {
            string response = await client.GetStringAsync(
                $"https://newsapi.org/v2/top-headlines?country=us&apiKey={ApiKey.key}");

            NewsResponse newsObject = JsonConvert.DeserializeObject<NewsResponse>(response);

            foreach( var article in newsObject.Articles)
            {
                Console.WriteLine(article.Title);
                Console.WriteLine();
                Console.WriteLine("Published:" + article.PublishedAt);
                Console.WriteLine();
                Console.WriteLine(article.Content);
                Console.WriteLine();
                Console.WriteLine("Read Article at:" + article.Url);
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        

    }
    class NewsResponse
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }

    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string PublishedAt { get; set; }
    }
}
