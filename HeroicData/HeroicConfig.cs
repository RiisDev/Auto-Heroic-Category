using System.Text.Json.Serialization;

namespace HeroicCategory.HeroicData;

public record Favourite(
    [property: JsonPropertyName("appName")] string AppName,
    [property: JsonPropertyName("title")] string Title
);

public record Games(
    [property: JsonPropertyName("customCategories")] Dictionary<string, List<string>> CustomCategories,
    [property: JsonPropertyName("favourites")] IReadOnlyList<Favourite> Favourites
);

public record GeneralLogs(
    [property: JsonPropertyName("currentLogFile")] string CurrentLogFile,
    [property: JsonPropertyName("lastLogFile")] string LastLogFile,
    [property: JsonPropertyName("legendaryLogFile")] string LegendaryLogFile,
    [property: JsonPropertyName("gogdlLogFile")] string GogdlLogFile,
    [property: JsonPropertyName("nileLogFile")] string NileLogFile
);

public record HeroicConfig(
    [property: JsonPropertyName("general-logs")] GeneralLogs GeneralLogs,
    [property: JsonPropertyName("userHome")] string UserHome,
    [property: JsonPropertyName("language")] string Language,
    [property: JsonPropertyName("userInfo")] UserInfo UserInfo,
    [property: JsonPropertyName("games")] Games Games,
    [property: JsonPropertyName("settings")] Settings Settings,
    [property: JsonPropertyName("window-props")] WindowProps WindowProps
);

public record Settings(
    [property: JsonPropertyName("checkUpdatesInterval")] int? CheckUpdatesInterval,
    [property: JsonPropertyName("enableUpdates")] bool? EnableUpdates,
    [property: JsonPropertyName("addDesktopShortcuts")] bool? AddDesktopShortcuts,
    [property: JsonPropertyName("addStartMenuShortcuts")] bool? AddStartMenuShortcuts,
    [property: JsonPropertyName("autoInstallDxvk")] bool? AutoInstallDxvk,
    [property: JsonPropertyName("autoInstallVkd3d")] bool? AutoInstallVkd3d,
    [property: JsonPropertyName("autoInstallDxvkNvapi")] bool? AutoInstallDxvkNvapi,
    [property: JsonPropertyName("addSteamShortcuts")] bool? AddSteamShortcuts,
    [property: JsonPropertyName("preferSystemLibs")] bool? PreferSystemLibs,
    [property: JsonPropertyName("checkForUpdatesOnStartup")] bool? CheckForUpdatesOnStartup,
    [property: JsonPropertyName("autoUpdateGames")] bool? AutoUpdateGames,
    [property: JsonPropertyName("customWinePaths")] IReadOnlyList<object> CustomWinePaths,
    [property: JsonPropertyName("defaultInstallPath")] string DefaultInstallPath,
    [property: JsonPropertyName("libraryTopSection")] string LibraryTopSection,
    [property: JsonPropertyName("defaultSteamPath")] string DefaultSteamPath,
    [property: JsonPropertyName("defaultWinePrefix")] string DefaultWinePrefix,
    [property: JsonPropertyName("hideChangelogsOnStartup")] bool? HideChangelogsOnStartup,
    [property: JsonPropertyName("language")] string Language,
    [property: JsonPropertyName("maxWorkers")] int? MaxWorkers,
    [property: JsonPropertyName("minimizeOnLaunch")] bool? MinimizeOnLaunch,
    [property: JsonPropertyName("nvidiaPrime")] bool? NvidiaPrime,
    [property: JsonPropertyName("enviromentOptions")] IReadOnlyList<object> EnviromentOptions,
    [property: JsonPropertyName("wrapperOptions")] IReadOnlyList<object> WrapperOptions,
    [property: JsonPropertyName("showFps")] bool? ShowFps,
    [property: JsonPropertyName("useGameMode")] bool? UseGameMode,
    [property: JsonPropertyName("wineCrossoverBottle")] string WineCrossoverBottle,
    [property: JsonPropertyName("winePrefix")] string WinePrefix,
    [property: JsonPropertyName("wineVersion")] WineVersion WineVersion,
    [property: JsonPropertyName("enableEsync")] bool? EnableEsync,
    [property: JsonPropertyName("enableFsync")] bool? EnableFsync,
    [property: JsonPropertyName("enableMsync")] bool? EnableMsync,
    [property: JsonPropertyName("eacRuntime")] bool? EacRuntime,
    [property: JsonPropertyName("battlEyeRuntime")] bool? BattlEyeRuntime,
    [property: JsonPropertyName("framelessWindow")] bool? FramelessWindow,
    [property: JsonPropertyName("beforeLaunchScriptPath")] string BeforeLaunchScriptPath,
    [property: JsonPropertyName("afterLaunchScriptPath")] string AfterLaunchScriptPath,
    [property: JsonPropertyName("disableUMU")] bool? DisableUMU,
    [property: JsonPropertyName("verboseLogs")] bool? VerboseLogs,
    [property: JsonPropertyName("egsLinkedPath")] string EgsLinkedPath,
    [property: JsonPropertyName("customThemesPath")] string CustomThemesPath
);

public record UserInfo(
    [property: JsonPropertyName("account_id")] string AccountId,
    [property: JsonPropertyName("displayName")] string DisplayName,
    [property: JsonPropertyName("user")] string User
);

public record WindowProps(
    [property: JsonPropertyName("x")] int? X,
    [property: JsonPropertyName("y")] int? Y,
    [property: JsonPropertyName("width")] int? Width,
    [property: JsonPropertyName("height")] int? Height,
    [property: JsonPropertyName("maximized")] bool? Maximized
);

public record WineVersion(

);

