
using System.Collections.Immutable;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using HeroicCategory;
using HeroicCategory.HeroicData;
using HeroicCategory.Misc;

string heroicData = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\heroic";
string heroicConfig = $"{heroicData}\\store\\config.json";

Write(true, "Doings run checks...");
(bool ranCheck, string errorMessage, Config? config) = await RunetimeInit.Check(heroicData, heroicConfig);
if (!ranCheck || config is null)
{
    Write(false, errorMessage);
    Console.ReadKey();
    return;
}

HttpClient client = new();
client.DefaultRequestHeaders.Add("Client-ID", config!.ClientId);

Write(true, "Building data object...");
HeroicConfig? heroicConfigData = JsonSerializer.Deserialize<HeroicConfig>(await File.ReadAllTextAsync(heroicConfig));
if (heroicConfigData is null) return;

Write(true, "Building category data...");
CategoryApi.CategoriesData catData = await CategoryApi.GetCategories(config?.ClientId ?? "", config?.ClientSecret ?? "", client)!;
if (catData is null) return;

Write(true, "Binding category data...");
foreach (CategoryApi.GenreData genres in catData.Genres.Where(genres => !heroicConfigData.Games.CustomCategories.ContainsKey(genres.Name)))
    heroicConfigData.Games.CustomCategories.Add(genres.Name, []);
foreach (CategoryApi.ThemesData themes in catData.ThemeData.Where(themes => !heroicConfigData.Games.CustomCategories.ContainsKey(themes.Name)))
    heroicConfigData.Games.CustomCategories.Add(themes.Name, []);
foreach (CategoryApi.GameModeData gameData in catData.GameModeData.Where(gameData => !heroicConfigData.Games.CustomCategories.ContainsKey(gameData.Name)))
    heroicConfigData.Games.CustomCategories.Add(gameData.Name, []);


Write(true, "Building game list...");
List<GameLibrary.GameData> games = await GameLibrary.Build(heroicData);

await Task.Delay(800);

Write(true, "Starting categorization...");
Write(false, "Closing the application will reset all progress, do not exit!");
ProgressBar bar = new();
const int maxRequestsPerSecond = 4;
TimeSpan delayBetweenRequests = TimeSpan.FromMilliseconds(1000 / maxRequestsPerSecond);
DateTime lastRequestTime = DateTime.UtcNow;

int done = 0;
bar.Report(done, games.Count);
foreach (GameLibrary.GameData game in games.Where(game => game.AppName != "gog-redist_gog"))
{
    done++;
    bar.Report(done, games.Count);
    TimeSpan timeSinceLastRequest = DateTime.UtcNow - lastRequestTime;
    if (timeSinceLastRequest < delayBetweenRequests) await Task.Delay(delayBetweenRequests - timeSinceLastRequest);

    lastRequestTime = DateTime.UtcNow;

    string data = await client.PostAsync($"https://api.igdb.com/v4/games/?search={game.Title}&fields=id,name,genres,themes,game_modes", new StringContent("")).Result.Content.ReadAsStringAsync();

    Debug.WriteLine(data);
    
    List<SearchResult>? searchResults = JsonSerializer.Deserialize<List<SearchResult>>(data);
    if (searchResults is null || searchResults.Count <= 0) continue;

    SearchResult gameResult = searchResults.First();

    if (gameResult.Genres is not null && gameResult.Genres.Count > 0)
    {
        foreach (int genreId in gameResult.Genres)
        {
            CategoryApi.GenreData? categoryData = catData.Genres.FirstOrDefault(x => x.Id == genreId);
            if (categoryData is null) continue;

            bool isInCategory = heroicConfigData.Games.CustomCategories[categoryData.Name].Any(x => x == game.Title);

            if (isInCategory) continue;
            ;
            heroicConfigData.Games.CustomCategories[categoryData.Name].Add(game.AppName);
        }
    }

    if (gameResult.Themes is not null && gameResult.Themes.Count > 0)
    {
        foreach (int genreId in gameResult.Themes)
        {
            CategoryApi.ThemesData? categoryData = catData.ThemeData.FirstOrDefault(x => x.Id == genreId);
            if (categoryData is null) continue;

            bool isInCategory = heroicConfigData.Games.CustomCategories[categoryData.Name].Any(x => x == game.Title);

            if (isInCategory) continue;
            ;
            heroicConfigData.Games.CustomCategories[categoryData.Name].Add(game.AppName);
        }
    }

    if (gameResult.GameModes is not null && gameResult.GameModes.Count > 0)
    {
        foreach (int genreId in gameResult.GameModes)
        {
            CategoryApi.GameModeData? categoryData = catData.GameModeData.FirstOrDefault(x => x.Id == genreId);
            if (categoryData is null) continue;

            bool isInCategory = heroicConfigData.Games.CustomCategories[categoryData.Name].Any(x => x == game.Title);

            if (isInCategory) continue;
            ;
            heroicConfigData.Games.CustomCategories[categoryData.Name].Add(game.AppName);
        }
    }
}

await File.WriteAllTextAsync(heroicConfig, Json.Serialize(heroicConfigData));
bar.Report(games.Count, games.Count);
return;

void Write(bool good, string message)
{
    Console.ForegroundColor = good ? ConsoleColor.Green : ConsoleColor.DarkRed;
    Console.WriteLine(message);
    Console.ResetColor();
}

record Config(string ClientId, string ClientSecret);
record SearchResult(
    [property: JsonPropertyName("id")] int? Id,
    [property: JsonPropertyName("genres")] IReadOnlyList<int>? Genres,
    [property: JsonPropertyName("themes")] IReadOnlyList<int>? Themes,
    [property: JsonPropertyName("game_modes")] IReadOnlyList<int>? GameModes,
    [property: JsonPropertyName("name")] string Name
);