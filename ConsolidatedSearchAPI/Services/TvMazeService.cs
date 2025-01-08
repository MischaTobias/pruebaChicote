using System.Text.Json;
using ConsolidatedSearchAPI.DTO;
using ConsolidatedSearchAPI.Models;

namespace ConsolidatedSearchAPI.Services;

public class TvMazeService(HttpClient httpClient, IConfiguration configuration) : ISearchService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string _TvMazeBaseUrl = configuration.GetValue<string>("ApiSettings:TvMazeBaseUrl") ?? "";

    private static readonly JsonSerializerOptions jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<List<SearchResult>> SearchAsync(string query)
    {
        var response = await _httpClient.GetAsync($"{_TvMazeBaseUrl}?q={query}");
        response.EnsureSuccessStatusCode();

        var jsonResult = await response.Content.ReadAsStringAsync();
        var results = JsonSerializer.Deserialize<List<TvMazeDto>>(jsonResult, jsonOptions);

        if (results == null || results.Count == 0)
        {
            return [];
        }

        return results.Select(r => new SearchResult
        {
            Source = "TVMaze",
            Title = r.Show?.Name ?? "Unknown Title",
            Description = r.Show?.Summary ?? "No Description Available",
            Url = r.Show?.Url?.ToString() ?? "No URL Available"
        }).ToList();
    }
}
