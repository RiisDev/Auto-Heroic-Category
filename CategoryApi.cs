using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HeroicCategory
{
    internal static class CategoryApi
    {
        record AuthTokenData(
            [property: JsonPropertyName("access_token")] string AccessToken,
            [property: JsonPropertyName("expires_in")] int? ExpiresIn,
            [property: JsonPropertyName("token_type")] string TokenType
        );

        public record GenreData(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("name")] string Name
        );

        public record ThemesData(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("name")] string Name
        );

        public record GameModeData(
            [property: JsonPropertyName("id")] int Id,
            [property: JsonPropertyName("name")] string Name
        );

        public record CategoriesData(
            List<GenreData> Genres,
            List<ThemesData> ThemeData,
            List<GameModeData> GameModeData
        );

        internal static async Task<string> GetAuthToken(string clientId, string clientSecret)
        {
            HttpClient client = new ();
            string data = await client.PostAsync($"https://id.twitch.tv/oauth2/token?client_id={clientId}&client_secret={clientSecret}&grant_type=client_credentials", new StringContent("")).Result.Content.ReadAsStringAsync();
            AuthTokenData? accessToken = JsonSerializer.Deserialize<AuthTokenData>(data);
            if (accessToken is null)
            {
                throw new Exception("Failed to get access token.");
            }
            return accessToken.AccessToken;
        }
        internal static async Task<CategoriesData> GetCategories(string clientId, string clientSecret, HttpClient client)
        {
            List<GenreData> genres = [];
            List<ThemesData> themeData = [];
            List<GameModeData> gameModeData = [];

            string authToken = await GetAuthToken(clientId, clientSecret);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            
            string data = await client.PostAsync("https://api.igdb.com/v4/genres", new StringContent("fields name, id; limit 500;")).Result.Content.ReadAsStringAsync();
            genres.AddRange(JsonSerializer.Deserialize<List<GenreData>>(data) ?? []);
            
            data = await client.PostAsync("https://api.igdb.com/v4/game_modes", new StringContent("fields name, id; limit 500;")).Result.Content.ReadAsStringAsync();
            gameModeData.AddRange(JsonSerializer.Deserialize<List<GameModeData>>(data) ?? []);
            
            data = await client.PostAsync("https://api.igdb.com/v4/themes", new StringContent("fields name, id; limit 500;")).Result.Content.ReadAsStringAsync();
            themeData.AddRange(JsonSerializer.Deserialize<List<ThemesData>>(data) ?? []);

            return new CategoriesData(genres, themeData, gameModeData);

        }
    }
}
