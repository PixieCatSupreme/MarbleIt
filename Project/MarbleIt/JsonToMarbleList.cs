using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MarbleIt
{
    public class JsonToMarbleList
    {
        public bool ConvertJson()
        {
            string path = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly()?.Location) ?? "";
            string inputPath = Path.Combine(path, "Input");

            string[] listNames = ReadFile(Path.Combine(path, "TrelloListNames.txt")).Split(Environment.NewLine);

            if (listNames.Length == 0 || string.IsNullOrWhiteSpace(listNames[0]))
            {
                Console.WriteLine("'TrelloListNames.txt' is empty! Please write down the Trello list names you want to export, one per line.");
                return false;
            }

            List<string> listIds = [];
            List<string> cardNames = [];

            if (!Directory.Exists(inputPath))
            {
                Console.WriteLine("Input path does not exist! Please create a folder named 'Input' next to the executable.");
                return false;
            }

            string? file = Directory.GetFiles(inputPath, "*.json").FirstOrDefault();

            if (file == null)
            {
                Console.WriteLine("No json file fount in 'Input' folder!");
                return false;
            }

            Console.WriteLine($"Read file '{file}'.");

            JsonNode? json = JsonArray.Parse(ReadFile(file));

            if (json == null)
            {
                Console.WriteLine("Unable to parse json file!");
                return false;
            }

            JsonArray? cards = json["cards"]?.AsArray();
            JsonArray? lists = json["lists"]?.AsArray();

            if (cards == null || lists == null)
            {
                Console.WriteLine("Could not find cards or lists in json!");
                return false;
            }

            Console.WriteLine($"Parsed json as trello board.");

            foreach (var list in lists)
            {
                string listName = list?["name"]?.GetValue<string>() ?? "";
                if (listNames.Contains(listName))
                {
                    string? id = list?["id"]?.GetValue<string>();

                    if(id == null)
                    {
                        Console.WriteLine($"Unable to read id of list '{listName}'!");
                        continue;
                    }

                    listIds.Add(id);
                }
            }

            Console.WriteLine($"Reading cards in {listIds.Count} lists.");

            foreach (var card in cards)
            {
                if (listIds.Contains(card?["idList"]?.GetValue<string>() ?? ""))
                {
                    string name = card?["name"]?.GetValue<string>() ?? "";

                    if (name == null)
                    {
                        Console.WriteLine($"Unable to read name of card!");
                        continue;
                    }

                    cardNames.Add(name);
                }
            }

            string fileName = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".csv";
            string exportPath = Path.Combine(path, "Output", fileName);

            Console.WriteLine($"Saving as '{exportPath}'.");

            WriteFile(exportPath, cardNames);

            Console.WriteLine($"Exported csv with {cardNames.Count} card names!");

            return true;
        }

        private static string ReadFile(string path)
        {
            using StreamReader r = new(path);
            return r.ReadToEnd();
        }

        private static void WriteFile(string path, List<string> items)
        {
            string dir = Path.GetDirectoryName(path) ?? "";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            using StreamWriter w = new(path);

            foreach (var item in items) 
            {
                w.WriteLine(item);
            }
        }
    }
}
