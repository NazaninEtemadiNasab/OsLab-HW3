using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace OsLab_HW3
{
    internal class Program
    {
        static void Main()
        {
            List<Human> allHumans = new List<Human>();

            // Get user input for human details
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter details for Human {i + 1}:");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                Console.Write("Birthday: ");
                string birthday = Console.ReadLine();
                Console.Write("National Code: ");
                int nationalCode = int.Parse(Console.ReadLine());
                Console.Write("Major: ");
                string major = Console.ReadLine();

                allHumans.Add(new Human { Name = name, LastName = lastName, Birthday = birthday, NationalCode = nationalCode, Major = major });
            }

            // Write to JSON file
            string json = JsonConvert.SerializeObject(allHumans, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(@"C:\Users\beta laptop\Desktop\New folder\Humansu1.json", json);
            Console.WriteLine("The list of humans has been successfully written to the JSON file.");
            Console.WriteLine("Please press any key to read from the JSON file.");
            Console.ReadKey();

            // Read from JSON file
            Console.WriteLine("\nReading from JSON file...\n");
            string jsonFromFile = File.ReadAllText(@"C:\Users\beta laptop\Desktop\New folder\Humansu1.json");
            List<Human> allHumansFromFile = JsonConvert.DeserializeObject<List<Human>>(jsonFromFile);

            foreach (var human in allHumansFromFile)
            {
                Console.WriteLine($"Name: {human.Name}, \n" +
                    $"Last Name: {human.LastName}, \n" +
                    $"Birthday: {human.Birthday}, \n" +
                    $"National Code: {human.NationalCode}, \n" +
                    $"Major: {human.Major}" +
                    "\n");
            }
            Console.WriteLine("Done.");
            Console.WriteLine("Please press any key to exit.");
            Console.ReadKey();
        }

        public struct Human
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string Birthday { get; set; }
            public int NationalCode { get; set; }
            public string Major { get; set; }
        }
    }
}