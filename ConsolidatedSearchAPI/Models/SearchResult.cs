namespace ConsolidatedSearchAPI.Models;

public class SearchResult
{
    public required string Source { get; set; } // "iTunes", "TVMaze", "CRCIND"
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Url { get; set; }
}
