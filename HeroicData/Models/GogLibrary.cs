// ReSharper disable CheckNamespace

using System.Text.Json.Serialization;

namespace HeroicCategory.HeroicData.Models.GogLibrary;
public record About(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("shortDescription")] string ShortDescription
);

public record Extra(
    [property: JsonPropertyName("about")] About About,
    [property: JsonPropertyName("reqs")] IReadOnlyList<object> Reqs,
    [property: JsonPropertyName("genres")] IReadOnlyList<string> Genres
);

public record Game(
    [property: JsonPropertyName("app_name")] string AppName,
    [property: JsonPropertyName("runner")] string Runner,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("canRunOffline")] bool? CanRunOffline,
    [property: JsonPropertyName("install")] Install Install,
    [property: JsonPropertyName("is_installed")] bool? IsInstalled,
    [property: JsonPropertyName("art_cover")] string ArtCover,
    [property: JsonPropertyName("art_square")] string ArtSquare,
    [property: JsonPropertyName("developer")] string Developer,
    [property: JsonPropertyName("art_background")] string ArtBackground,
    [property: JsonPropertyName("cloud_save_enabled")] bool? CloudSaveEnabled,
    [property: JsonPropertyName("art_icon")] string ArtIcon,
    [property: JsonPropertyName("extra")] Extra Extra,
    [property: JsonPropertyName("folder_name")] string FolderName,
    [property: JsonPropertyName("save_folder")] string SaveFolder,
    [property: JsonPropertyName("is_mac_native")] bool? IsMacNative,
    [property: JsonPropertyName("is_linux_native")] bool? IsLinuxNative
);

public record Install(
    [property: JsonPropertyName("is_dlc")] bool? IsDlc
);

public record GogLibrary(
    [property: JsonPropertyName("games")] IReadOnlyList<Game> Games,
    [property: JsonPropertyName("__timestamp")] Timestamp Timestamp
);

public record Timestamp(
    [property: JsonPropertyName("games")] string Games
);

