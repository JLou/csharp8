using System;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace Snippets
{
    public class AsyncStreams
    {
        public static async Task RunAsync()
        {
            #region async-stream
            var amount = 12;
            await foreach (var fact in GetFactsAsync(amount))
            {
                Console.WriteLine($"Here's a fun fact: {fact}");
            }
            #endregion
        }

        private static HttpClient CreateClient()
        {
            var handler = new HttpClientHandler()
            {
                Proxy = new WebProxy("http://127.0.0.1:5000")
            };
            return new HttpClient(handler);
        }
        private static async IAsyncEnumerable<string> GetFactsAsync(int amount)
        {
            var client = CreateClient();
            var unusedNumbersList = Enumerable.Range(1, 100).ToList();
            unusedNumbersList.Shuffle();
            var unusedNumbers = new Stack<int>(unusedNumbersList.Take(amount));

            while (unusedNumbers.Count > 0)
            {
                var item = unusedNumbers.Pop();
                var response = await client.GetAsync($"http://numbersapi.com/{item}");
                yield return await response.Content.ReadAsStringAsync();
            }
        }
    }
    public static class IListExtensions
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}