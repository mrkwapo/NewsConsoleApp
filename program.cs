using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BusinessNewsApp
{
    public class Program
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
            Console.WriteLine(response);
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
    }
}
