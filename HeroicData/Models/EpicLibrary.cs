// ReSharper disable CheckNamespace

using System.Text.Json.Serialization;

namespace HeroicCategory.HeroicData.Models.EpicLibrary;
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
public record About(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("shortDescription")] string ShortDescription
);

public record ACB(
    [property: JsonPropertyName("ageControl")] int? AgeControl,
    [property: JsonPropertyName("descriptorIds")] IReadOnlyList<object> DescriptorIds,
    [property: JsonPropertyName("elementIds")] IReadOnlyList<object> ElementIds,
    [property: JsonPropertyName("gameRating")] string GameRating,
    [property: JsonPropertyName("isIARC")] bool? IsIARC,
    [property: JsonPropertyName("isTrad")] bool? IsTrad,
    [property: JsonPropertyName("ratingImage")] string RatingImage,
    [property: JsonPropertyName("ratingSystem")] string RatingSystem,
    [property: JsonPropertyName("rectangularRatingImage")] string RectangularRatingImage,
    [property: JsonPropertyName("title")] string Title
);

public record AgeGatings(
    [property: JsonPropertyName("ESRB")] ESRB ESRB,
    [property: JsonPropertyName("GRAC")] GRAC GRAC,
    [property: JsonPropertyName("ACB")] ACB ACB,
    [property: JsonPropertyName("ClassInd")] ClassInd ClassInd,
    [property: JsonPropertyName("OFLC")] OFLC OFLC,
    [property: JsonPropertyName("PEGI")] PEGI PEGI,
    [property: JsonPropertyName("USK")] USK USK
);

public record CanRunOffline(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record CanSkipKoreanIdVerification(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record Category(
    [property: JsonPropertyName("path")] string Path
);

public record ClassInd(
    [property: JsonPropertyName("ageControl")] int? AgeControl,
    [property: JsonPropertyName("descriptorIds")] IReadOnlyList<object> DescriptorIds,
    [property: JsonPropertyName("elementIds")] IReadOnlyList<object> ElementIds,
    [property: JsonPropertyName("gameRating")] string GameRating,
    [property: JsonPropertyName("isIARC")] bool? IsIARC,
    [property: JsonPropertyName("isTrad")] bool? IsTrad,
    [property: JsonPropertyName("ratingImage")] string RatingImage,
    [property: JsonPropertyName("ratingSystem")] string RatingSystem,
    [property: JsonPropertyName("rectangularRatingImage")] string RectangularRatingImage,
    [property: JsonPropertyName("title")] string Title
);

public record CustomAttributes(
    [property: JsonPropertyName("CanRunOffline")] CanRunOffline CanRunOffline,
    [property: JsonPropertyName("FolderName")] FolderName FolderName,
    [property: JsonPropertyName("mods.installPath")] ModsInstallPath ModsInstallPath,
    [property: JsonPropertyName("OwnershipToken")] OwnershipToken OwnershipToken,
    [property: JsonPropertyName("isPrepurchase")] IsPrepurchase IsPrepurchase,
    [property: JsonPropertyName("CanSkipKoreanIdVerification")] CanSkipKoreanIdVerification CanSkipKoreanIdVerification,
    [property: JsonPropertyName("MonitorPresence")] MonitorPresence MonitorPresence,
    [property: JsonPropertyName("PresenceId")] PresenceId? data2,
    [property: JsonPropertyName("RequirementsJson")] RequirementsJson RequirementsJson,
    [property: JsonPropertyName("UseAccessControl")] UseAccessControl UseAccessControl,
    [property: JsonPropertyName("parentPartnerLinkId")] ParentPartnerLinkId ParentPartnerLinkId,
    [property: JsonPropertyName("partnerLinkId")] PartnerLinkId PartnerLinkId,
    [property: JsonPropertyName("partnerLinkType")] PartnerLinkType PartnerLinkType,
    [property: JsonPropertyName("SupportedPlatforms")] SupportedPlatforms SupportedPlatforms,
    [property: JsonPropertyName("PresenceID")] PresenceId? data,
    [property: JsonPropertyName("developerName")] DeveloperName DeveloperName
);

public record DeveloperName(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record DlcList(
    [property: JsonPropertyName("ageGatings")] AgeGatings AgeGatings,
    [property: JsonPropertyName("categories")] IReadOnlyList<Category> Categories,
    [property: JsonPropertyName("creationDate")] DateTime? CreationDate,
    [property: JsonPropertyName("customAttributes")] CustomAttributes CustomAttributes,
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("developer")] string Developer,
    [property: JsonPropertyName("developerId")] string DeveloperId,
    [property: JsonPropertyName("endOfSupport")] bool? EndOfSupport,
    [property: JsonPropertyName("entitlementName")] string EntitlementName,
    [property: JsonPropertyName("entitlementType")] string EntitlementType,
    [property: JsonPropertyName("eulaIds")] IReadOnlyList<string> EulaIds,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("itemType")] string ItemType,
    [property: JsonPropertyName("keyImages")] IReadOnlyList<KeyImage> KeyImages,
    [property: JsonPropertyName("lastModifiedDate")] DateTime? LastModifiedDate,
    [property: JsonPropertyName("mainGameItem")] MainGameItem MainGameItem,
    [property: JsonPropertyName("mainGameItemList")] IReadOnlyList<MainGameItemList> MainGameItemList,
    [property: JsonPropertyName("namespace")] string Namespace,
    [property: JsonPropertyName("releaseInfo")] IReadOnlyList<ReleaseInfo> ReleaseInfo,
    [property: JsonPropertyName("status")] string Status,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("unsearchable")] bool? Unsearchable,
    [property: JsonPropertyName("applicationId")] string ApplicationId,
    [property: JsonPropertyName("installModes")] IReadOnlyList<object> InstallModes,
    [property: JsonPropertyName("longDescription")] string LongDescription,
    [property: JsonPropertyName("requiresSecureAccount")] bool? RequiresSecureAccount,
    [property: JsonPropertyName("esrbGameRatingValue")] string EsrbGameRatingValue,
    [property: JsonPropertyName("useCount")] int? UseCount,
    [property: JsonPropertyName("technicalDetails")] string TechnicalDetails
);

public record ESRB(
    [property: JsonPropertyName("ageControl")] int? AgeControl,
    [property: JsonPropertyName("descriptor")] string Descriptor,
    [property: JsonPropertyName("descriptorIds")] IReadOnlyList<int?> DescriptorIds,
    [property: JsonPropertyName("gameRating")] string GameRating,
    [property: JsonPropertyName("isIARC")] bool? IsIARC,
    [property: JsonPropertyName("isTrad")] bool? IsTrad,
    [property: JsonPropertyName("ratingImage")] string RatingImage,
    [property: JsonPropertyName("ratingSystem")] string RatingSystem,
    [property: JsonPropertyName("rectangularRatingImage")] string RectangularRatingImage,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("element")] string Element,
    [property: JsonPropertyName("elementIds")] IReadOnlyList<int?> ElementIds
);

public record Extra(
    [property: JsonPropertyName("about")] About About,
    [property: JsonPropertyName("reqs")] IReadOnlyList<object> Reqs,
    [property: JsonPropertyName("storeUrl")] string StoreUrl
);

public record FolderName(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record GRAC(
    [property: JsonPropertyName("ageControl")] int? AgeControl,
    [property: JsonPropertyName("descriptor")] string Descriptor,
    [property: JsonPropertyName("descriptorIds")] IReadOnlyList<int?> DescriptorIds,
    [property: JsonPropertyName("gameRating")] string GameRating,
    [property: JsonPropertyName("isIARC")] bool? IsIARC,
    [property: JsonPropertyName("isTrad")] bool? IsTrad,
    [property: JsonPropertyName("ratingImage")] string RatingImage,
    [property: JsonPropertyName("ratingSystem")] string RatingSystem,
    [property: JsonPropertyName("rectangularRatingImage")] string RectangularRatingImage,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("elementIds")] IReadOnlyList<object> ElementIds
);

public record Install(
    [property: JsonPropertyName("install_size")] string InstallSize,
    [property: JsonPropertyName("is_dlc")] bool? IsDlc
);

public record IsPrepurchase(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record KeyImage(
    [property: JsonPropertyName("height")] int? Height,
    [property: JsonPropertyName("md5")] string Md5,
    [property: JsonPropertyName("size")] int? Size,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("uploadedDate")] DateTime? UploadedDate,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("width")] int? Width,
    [property: JsonPropertyName("alt")] string Alt
);

public record Library(
    [property: JsonPropertyName("app_name")] string AppName,
    [property: JsonPropertyName("art_cover")] string ArtCover,
    [property: JsonPropertyName("art_square")] string ArtSquare,
    [property: JsonPropertyName("cloud_save_enabled")] bool? CloudSaveEnabled,
    [property: JsonPropertyName("developer")] string Developer,
    [property: JsonPropertyName("extra")] Extra Extra,
    [property: JsonPropertyName("folder_name")] string FolderName,
    [property: JsonPropertyName("install")] Install Install,
    [property: JsonPropertyName("is_installed")] bool? IsInstalled,
    [property: JsonPropertyName("namespace")] string Namespace,
    [property: JsonPropertyName("is_mac_native")] bool? IsMacNative,
    [property: JsonPropertyName("save_folder")] string SaveFolder,
    [property: JsonPropertyName("title")] string Title,
    [property: JsonPropertyName("canRunOffline")] bool? CanRunOffline,
    [property: JsonPropertyName("isEAManaged")] bool? IsEAManaged,
    [property: JsonPropertyName("is_linux_native")] bool? IsLinuxNative,
    [property: JsonPropertyName("runner")] string Runner,
    [property: JsonPropertyName("store_url")] string StoreUrl,
    [property: JsonPropertyName("dlcList")] IReadOnlyList<DlcList> DlcList,
    [property: JsonPropertyName("thirdPartyManagedApp")] string ThirdPartyManagedApp,
    [property: JsonPropertyName("art_logo")] string ArtLogo
);

public record MainGameItem(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("namespace")] string Namespace,
    [property: JsonPropertyName("unsearchable")] bool? Unsearchable
);

public record MainGameItemList(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("namespace")] string Namespace,
    [property: JsonPropertyName("unsearchable")] bool? Unsearchable
);

public record ModsInstallPath(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record MonitorPresence(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record OFLC(
    [property: JsonPropertyName("ageControl")] int? AgeControl,
    [property: JsonPropertyName("elementIds")] IReadOnlyList<object> ElementIds,
    [property: JsonPropertyName("gameRating")] string GameRating,
    [property: JsonPropertyName("isIARC")] bool? IsIARC,
    [property: JsonPropertyName("isTrad")] bool? IsTrad,
    [property: JsonPropertyName("ratingImage")] string RatingImage,
    [property: JsonPropertyName("ratingSystem")] string RatingSystem,
    [property: JsonPropertyName("title")] string Title
);

public record OwnershipToken(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record ParentPartnerLinkId(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record PartnerLinkId(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record PartnerLinkType(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record PEGI(
    [property: JsonPropertyName("ageControl")] int? AgeControl,
    [property: JsonPropertyName("descriptor")] string Descriptor,
    [property: JsonPropertyName("descriptorIds")] IReadOnlyList<int?> DescriptorIds,
    [property: JsonPropertyName("elementIds")] IReadOnlyList<object> ElementIds,
    [property: JsonPropertyName("gameRating")] string GameRating,
    [property: JsonPropertyName("isIARC")] bool? IsIARC,
    [property: JsonPropertyName("isTrad")] bool? IsTrad,
    [property: JsonPropertyName("ratingImage")] string RatingImage,
    [property: JsonPropertyName("ratingSystem")] string RatingSystem,
    [property: JsonPropertyName("rectangularRatingImage")] string RectangularRatingImage,
    [property: JsonPropertyName("title")] string Title
);

public record PresenceId(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record PresenceID2(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record ReleaseInfo(
    [property: JsonPropertyName("appId")] string AppId,
    [property: JsonPropertyName("compatibleApps")] IReadOnlyList<object> CompatibleApps,
    [property: JsonPropertyName("dateAdded")] DateTime? DateAdded,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("platform")] IReadOnlyList<string> Platform,
    [property: JsonPropertyName("releaseNote")] string ReleaseNote,
    [property: JsonPropertyName("versionTitle")] string VersionTitle
);

public record RequirementsJson(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record EpicLibrary(
    [property: JsonPropertyName("library")] IReadOnlyList<Library> Library,
    [property: JsonPropertyName("__timestamp")] Timestamp Timestamp
);

public record SupportedPlatforms(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record Timestamp(
    [property: JsonPropertyName("library")] string Library
);

public record UseAccessControl(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("value")] string Value
);

public record USK(
    [property: JsonPropertyName("ageControl")] int? AgeControl,
    [property: JsonPropertyName("descriptorIds")] IReadOnlyList<object> DescriptorIds,
    [property: JsonPropertyName("elementIds")] IReadOnlyList<object> ElementIds,
    [property: JsonPropertyName("gameRating")] string GameRating,
    [property: JsonPropertyName("isIARC")] bool? IsIARC,
    [property: JsonPropertyName("isTrad")] bool? IsTrad,
    [property: JsonPropertyName("ratingImage")] string RatingImage,
    [property: JsonPropertyName("ratingSystem")] string RatingSystem,
    [property: JsonPropertyName("rectangularRatingImage")] string RectangularRatingImage,
    [property: JsonPropertyName("title")] string Title
);

