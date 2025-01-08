using System.Text.Json;
using ConsolidatedSearchAPI.DTO;
using ConsolidatedSearchAPI.Models;

namespace ConsolidatedSearchAPI.Services;

public class ITunesService(HttpClient httpClient, IConfiguration configuration) : ISearchService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string _iTunesBaseUrl = configuration.GetValue<string>("ApiSettings:iTunesBaseUrl") ?? "";

    private static readonly JsonSerializerOptions jsonOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<List<SearchResult>> SearchAsync(string query)
    {
        var response = await _httpClient.GetAsync($"{_iTunesBaseUrl}?term={query}");
        response.EnsureSuccessStatusCode();

        var jsonResult = await response.Content.ReadAsStringAsync();
        var iTunesDto = JsonSerializer.Deserialize<ITunesDTO>(jsonResult, jsonOptions);
        var results = iTunesDto?.Results;

        if (results == null || results.Count == 0)
        {
            return [];
        }

        return results.Select(r => new SearchResult
        {
            Source = "iTunes",
            Title = r.TrackName ?? "Unknown Title",
            Description = r.CollectionName ?? "No Description Available",
            Url = r.TrackViewUrl?.ToString() ?? "No URL Available",
        }).ToList();
    }
}
