using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab2Async
{
    class aSyncVersion
    {
        static async Task Main(string[] args)
        {
            string[] urls = {
                "https://jsonplaceholder.typicode.com/posts/1",
                "https://api.spacexdata.com/v4/launches/latest",
                "https://official-joke-api.appspot.com/random_joke"
            };

            HttpClient client = new HttpClient();
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("===== АСИНХРОННЫЕ ЗАПРОСЫ =====");

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine($"\nЗапрос к {url}");
                    var response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("Ответ:\n" + content);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: " + response.StatusCode);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Исключение: " + ex.Message);
                }
            }

            sw.Stop();
            Console.WriteLine($"\nОбщее время: {sw.ElapsedMilliseconds} мс");
        }
    }
}
