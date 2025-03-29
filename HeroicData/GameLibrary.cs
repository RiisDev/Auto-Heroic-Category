using System.Text.Json;
using HeroicCategory.HeroicData.Models.AmazonLibrary;
using HeroicCategory.HeroicData.Models.EpicLibrary;
using HeroicCategory.HeroicData.Models.GogLibrary;

namespace HeroicCategory.HeroicData
{
    internal static class GameLibrary
    {
        internal record GameData(string Title, string AppName);
        internal static async Task<List<GameData>> Build(string heroicData)
        {
            List<GameData> games = [];

            if (File.Exists($@"{heroicData}\store_cache\gog_library.json"))
            {
                GogLibrary? gogData = JsonSerializer.Deserialize<GogLibrary>(await File.ReadAllTextAsync($@"{heroicData}\store_cache\gog_library.json"));
                if (gogData is not null) games.AddRange(gogData.Games.Select(game => new GameData(game.Title, game.AppName + "_gog")));
            }
            if (File.Exists($@"{heroicData}\store_cache\legendary_library.json"))
            {
                EpicLibrary? epicData = JsonSerializer.Deserialize<EpicLibrary>(await File.ReadAllTextAsync($@"{heroicData}\store_cache\legendary_library.json"));
                if (epicData is not null) games.AddRange(epicData.Library.Select(game => new GameData(game.Title, game.AppName + "_legendary")));
            }
            // ReSharper disable once InvertIf
            if (File.Exists($@"{heroicData}\store_cache\nile_library.json"))
            {
                AmazonLibrary? amazonData = JsonSerializer.Deserialize<AmazonLibrary>(await File.ReadAllTextAsync($@"{heroicData}\store_cache\nile_library.json"));
                if (amazonData is not null) games.AddRange(amazonData.Library.Select(game => new GameData(game.Title, game.AppName + "_nile")));
            }

            return games;
        }
    }
}
