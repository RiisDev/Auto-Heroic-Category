using System.Text.Json.Serialization;
// ReSharper disable CheckNamespace

namespace HeroicCategory.HeroicData.Models.AmazonLibrary;
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record Extra(
    [property: JsonPropertyName("reqs")] IReadOnlyList<object> Reqs,
    [property: JsonPropertyName("genres")] IReadOnlyList<string> Genres,
    [property: JsonPropertyName("releaseDate")] DateTime? ReleaseDate
);


public record Library(
    [property: JsonPropertyName("app_name")] string AppName,
    [property: JsonPropertyName("art_cover")] string ArtCover,
    [property: JsonPropertyName("art_logo")] string ArtLogo,
    [property: JsonPropertyName("art_background")] string ArtBackground,
    [property: JsonPropertyName("art_square")] string ArtSquare,
    [property: JsonPropertyName("canRunOffline")] bool? CanRunOffline,
    [property: JsonPropertyName("install")] dynamic Install,
    [property: JsonPropertyName("folder_name")] string FolderName,
    [property: JsonPropertyName("is_installed")] bool? IsInstalled,
    [property: JsonPropertyName("runner")] string Runner,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("developer")] string Developer,
    [property: JsonPropertyName("extra")] Extra Extra,
    [property: JsonPropertyName("is_linux_native")] bool? IsLinuxNative,
    [property: JsonPropertyName("is_mac_native")] bool? IsMacNative,
    [property: JsonPropertyName("description")] string Description
);

public record AmazonLibrary(
    [property: JsonPropertyName("library")] IReadOnlyList<Library> Library,
    [property: JsonPropertyName("__timestamp")] Timestamp Timestamp
);

public record Timestamp(
    [property: JsonPropertyName("library")] string Library
);

