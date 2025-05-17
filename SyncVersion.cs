using System;
using System.Diagnostics;
using System.Net.Http;

namespace Lab2Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] urls = {
                "https://jsonplaceholder.typicode.com/posts/1",
                "https://api.spacexdata.com/v4/launches/latest",
                "https://official-joke-api.appspot.com/random_joke"
            };

            HttpClient client = new HttpClient();
            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("===== СИНХРОННЫЕ ЗАПРОСЫ =====");

            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine($"\nЗапрос к {url}");
                    var response = client.GetAsync(url).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string content = response.Content.ReadAsStringAsync().Result;
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
