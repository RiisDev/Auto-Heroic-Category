using System.Text.Json;

namespace HeroicCategory.Misc
{
    internal static class RunetimeInit
    {
        static void Write(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        internal static async Task<(bool, string, Config?)> Check(string heroicData, string heroicConfig)
        {
            string[] softNames = ["gog", "legendary", "nile"];

            Write("Checking for config.json...");
            if (!File.Exists("config.json"))
            {
                await File.WriteAllTextAsync("config.json", JsonSerializer.Serialize(new Config("", "")));
                return (false, "Please fill in the config.json file with your ClientId and ClientSecret.", null);
            }

            Write("Reading config.json...");
            Config? config = JsonSerializer.Deserialize<Config>(await File.ReadAllTextAsync("config.json"));

            if (string.IsNullOrEmpty(config?.ClientId) || string.IsNullOrEmpty(config.ClientSecret))
                return (false, "Please fill in the config.json file with your ClientId and ClientSecret.", null);

            Write("Checking for game library...");
            foreach (string softName in softNames)
            {
                if (File.Exists($"{heroicData}\\store_cache\\{softName}_library.json")) continue;

                Console.ForegroundColor = ConsoleColor.DarkRed;
                await Console.Error.WriteLineAsync($"Failed to find: {softName}");
                Console.ResetColor();
            }

            Write("Checking for heroic base data...");
            if (!File.Exists(heroicConfig))
                return (false, $"Failed to find: {heroicConfig}", null);

            Write("Checking for temp category...");
            if ((await File.ReadAllTextAsync(heroicConfig)).Contains("customCategories")) return (true, "", config);
            
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Please create an empty category in heroic before proceeding.");
            Console.ResetColor();

            return (true, "", config);
        }
    }
}
