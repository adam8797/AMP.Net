using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using AMP.Net;

namespace TestClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new AmpClientCollection("https://amp.schiavone.io");
            await client.Core.LoginAsync("adam", "$0y9tborY70p");
            var instances = await client.ADSModule.GetInstancesAsync();

        }

        public class Test
        {
            public Guid Id { get; set; }
        }

        static void Print(object o)
        {
            Console.WriteLine(JsonSerializer.Serialize(o, new JsonSerializerOptions() { WriteIndented = true }));
        }
    }
}
