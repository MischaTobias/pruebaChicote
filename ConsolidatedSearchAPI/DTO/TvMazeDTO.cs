namespace ConsolidatedSearchAPI.DTO;

partial class TvMazeDto
{
    public double? Score { get; set; }
    public Show? Show { get; set; }
}

public partial class Show
{
    public long? Id { get; set; }
    public Uri? Url { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Language { get; set; }
    public string[]? Genres { get; set; }
    public string? Status { get; set; }
    public long? Runtime { get; set; }
    public long? AverageRuntime { get; set; }
    public DateTimeOffset? Premiered { get; set; }
    public DateTimeOffset? Ended { get; set; }
    public Uri? OfficialSite { get; set; }
    public Schedule? Schedule { get; set; }
    public Rating? Rating { get; set; }
    public long? Weight { get; set; }
    public Network? Network { get; set; }
    public object? WebChannel { get; set; }
    public object? DvdCountry { get; set; }
    public Externals? Externals { get; set; }
    public Image? Image { get; set; }
    public string? Summary { get; set; }
    public long? Updated { get; set; }
    public Links? Links { get; set; }
}
public partial class Externals
{
    public long? Tvrage { get; set; }
    public long? Thetvdb { get; set; }
    public string? Imdb { get; set; }
}
public partial class Image
{
    public Uri? Medium { get; set; }
    public Uri? Original { get; set; }
}
public partial class Links
{
    public Self? Self { get; set; }
    public Previousepisode? Previousepisode { get; set; }
}
public partial class Previousepisode
{
    public Uri? Href { get; set; }
    public string? Name { get; set; }
}
public partial class Self
{
    public Uri? Href { get; set; }
}
public partial class Network
{
    public long? Id { get; set; }
    public string? Name { get; set; }
    public TvMazeCountry? Country { get; set; }
    public Uri? OfficialSite { get; set; }
}
public partial class TvMazeCountry
{
    public string? Name { get; set; }
    public string? Code { get; set; }
    public string? Timezone { get; set; }
}
public partial class Rating
{
    public double? Average { get; set; }
}
public partial class Schedule
{
    public string? Time { get; set; }
    public string[]? Days { get; set; }
}