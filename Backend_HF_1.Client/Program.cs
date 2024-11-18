
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.IO;
using System.Text;

namespace Backend_HF_1.Client
{
    internal class Program
    {
        const string baseUrl = "http://localhost:5051";
        const string baseUrl2 = "https://localhost:7108";
        const string path = "InputData/InputData.json";

        static async Task Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("Read in a file: press 1" +
                    "\nAdd singular Data: 2" +
                    "\nGet Monthly statistics: 3");
                var input = Console.ReadKey().Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        await UploadEntriesFromFile();

                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        break;
                    default:
                        break;
                }
            }
        }

        public static async Task<bool> UploadEntriesFromFile()
        {
            Console.WriteLine("Reading file.....");

            var jsonString = File.ReadAllText(path); //Get-nel nincs ez
            var url = baseUrl + "/api/WaterLevel/AddWaterList";

            using var client = new HttpClient();
            try
            {
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json"); //Get-nel ez sincs

                var response = await client.PostAsync(url, content); //Post async helyett client.GetAsync van csak az URl van parameternek
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"There was an error {ex.Message}");
                return false;
            }
            return true;


        }


    }
}
