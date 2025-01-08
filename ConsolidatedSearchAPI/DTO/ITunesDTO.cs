namespace ConsolidatedSearchAPI.DTO;


public partial class ITunesDTO
{
    public long ResultCount { get; set; }
    public List<Result>? Results { get; set; }
}

public partial class Result
{
    public string? WrapperType { get; set; }
    public string? Kind { get; set; }
    public long? CollectionId { get; set; }
    public long TrackId { get; set; }
    public string? ArtistName { get; set; }
    public string? CollectionName { get; set; }
    public string? TrackName { get; set; }
    public string? CollectionCensoredName { get; set; }
    public string? TrackCensoredName { get; set; }
    public long? CollectionArtistId { get; set; }
    public Uri? CollectionArtistViewUrl { get; set; }
    public Uri? CollectionViewUrl { get; set; }
    public Uri? TrackViewUrl { get; set; }
    public Uri? PreviewUrl { get; set; }
    public Uri? ArtworkUrl30 { get; set; }
    public Uri? ArtworkUrl60 { get; set; }
    public Uri? ArtworkUrl100 { get; set; }
    public double? CollectionPrice { get; set; }
    public double? TrackPrice { get; set; }
    public double? TrackRentalPrice { get; set; }
    public double? CollectionHdPrice { get; set; }
    public double? TrackHdPrice { get; set; }
    public double? TrackHdRentalPrice { get; set; }
    public DateTimeOffset ReleaseDate { get; set; }
    public string? CollectionExplicitness { get; set; }
    public string? TrackExplicitness { get; set; }
    public long? DiscCount { get; set; }
    public long? DiscNumber { get; set; }
    public long? TrackCount { get; set; }
    public long? TrackNumber { get; set; }
    public long TrackTimeMillis { get; set; }
    public string? Country { get; set; }
    public string? Currency { get; set; }
    public string? PrimaryGenreName { get; set; }
    public string? ContentAdvisoryRating { get; set; }
    public string? ShortDescription { get; set; }
    public string? LongDescription { get; set; }
    public bool? HasITunesExtras { get; set; }
    public long? ArtistId { get; set; }
    public Uri? ArtistViewUrl { get; set; }
    public bool? IsStreamable { get; set; }
    public string? CollectionArtistName { get; set; }
}

