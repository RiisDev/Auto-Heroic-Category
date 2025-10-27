using System.Text.Json;
using HeroicCategory.HeroicData.Models.AmazonLibrary;
using HeroicCategory.HeroicData.Models.EpicLibrary;
using HeroicCategory.HeroicData.Models.GogLibrary;

namespace AutoHeroicCategory.HeroicData
{
	internal static class GameLibrary
	{
		internal record GameData(string Title, string AppName);
		internal static async Task<List<GameData>> Build(string heroicData)
		{
			List<GameData> games = [];

			if (File.Exists($@"{heroicData}\store_cache\gog_library.json"))
			{
				try
				{
					GogLibrary? gogData =
						JsonSerializer.Deserialize<GogLibrary>(
							await File.ReadAllTextAsync($@"{heroicData}\store_cache\gog_library.json"));
					if (gogData is not null && gogData.Games.Count > 0)
						games.AddRange(gogData.Games.Select(game => new GameData(game.Title, game.AppName + "_gog")));
				}
				catch (Exception ex)
				{
					Write(false, $"Failed to build GOG Library: {ex.Message}");
				}
			}

			if (File.Exists($@"{heroicData}\store_cache\legendary_library.json"))
			{
				try
				{
					EpicLibrary? epicData = JsonSerializer.Deserialize<EpicLibrary>(
						await File.ReadAllTextAsync($@"{heroicData}\store_cache\legendary_library.json"));
					if (epicData is not null && epicData.Library.Count > 0)
						games.AddRange(epicData.Library.Select(game =>
							new GameData(game.Title, game.AppName + "_legendary")));
				}
				catch (Exception ex)
				{
					Write(false, $"Failed to build Epic Library: {ex.Message}");
				}
			}

			// ReSharper disable once InvertIf
			if (File.Exists($@"{heroicData}\store_cache\nile_library.json"))
			{
				try
				{

					AmazonLibrary? amazonData =
						JsonSerializer.Deserialize<AmazonLibrary>(
							await File.ReadAllTextAsync($@"{heroicData}\store_cache\nile_library.json"));
					if (amazonData is not null && amazonData.Library.Count > 0)
						games.AddRange(amazonData.Library.Select(game =>
							new GameData(game.Title, game.AppName + "_nile")));
				}
				catch (Exception ex)
				{
					Write(false, $"Failed to build Amazon Library: {ex.Message}");
				}
			}

			return games;
		}
	}
}
