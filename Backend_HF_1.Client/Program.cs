
using Backend_HF_1.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Backend_HF_1.Client
{
    internal class Program
    {
        const string baseUrl = "http://localhost:5051";
        const string baseUrl2 = "https://localhost:7108";
        const string path = "InputData/InputData.json";

        static async Task Main(string[] args)
        {
            // Menu options
            string[] menuItems = { "Read File", "Get Monthly statistics", "Exit" };
            bool exit = false;

            while (!exit)
            {
                // Index of the currently selected menu item
                int selectedIndex = 0;

                // Run the menu loop
                ConsoleKey key;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Use Arrow Keys to navigate and Enter to select:\n");

                    // Display the menu items
                    for (int i = 0; i < menuItems.Length; i++)
                    {
                        if (i == selectedIndex)
                        {
                            // Highlight the selected menu item
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            // Default menu item colors
                            Console.ResetColor();
                        }

                        Console.WriteLine(menuItems[i]);
                    }

                    // Reset console colors after printing the menu
                    Console.ResetColor();

                    // Capture the user key press
                    key = Console.ReadKey(true).Key;

                    // Navigate menu with arrow keys
                    switch (key)
                    {
                        case ConsoleKey.UpArrow:
                            selectedIndex = (selectedIndex == 0) ? menuItems.Length - 1 : selectedIndex - 1;
                            break;

                        case ConsoleKey.DownArrow:
                            selectedIndex = (selectedIndex == menuItems.Length - 1) ? 0 : selectedIndex + 1;
                            break;
                    }
                } while (key != ConsoleKey.Enter); // Exit the loop when Enter is pressed

                // Output the selected menu option
                Console.Clear();
                if (selectedIndex == 0)
                {
                    Console.WriteLine($"You selected: {menuItems[selectedIndex]}");
                    await UploadEntriesFromFile();
                }
                else if (selectedIndex == 1)
                {
                    Console.WriteLine($"You selected: {menuItems[selectedIndex]}");
                    await GetMonthlyStatistics();

                }
                else if(selectedIndex == 2)
                {
                        break;
                }
                Console.WriteLine("Press any key to return");
                Console.ReadKey();
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

        public static async Task<bool> GetMonthlyStatistics()
        {
            Console.WriteLine("Gathering records.....");

            var url = baseUrl + "/api/WaterLevel";

            using var client = new HttpClient();
            try
            {
                var response = await client.GetAsync(url); //Post async helyett client.GetAsync van csak az URl van parameternek
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                //var options = new JsonSerializerOptions
                //{
                //    PropertyNameCaseInsensitive = true
                //};
                var output = JsonSerializer.Deserialize<List<MonthlyStatistics>>(responseBody);
                if (output != null)
                {
                    foreach (var item in output)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("No data received.");
                }
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
