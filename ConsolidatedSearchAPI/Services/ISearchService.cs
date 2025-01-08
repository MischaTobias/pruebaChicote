using ConsolidatedSearchAPI.Models;

namespace ConsolidatedSearchAPI.Services;

public interface ISearchService
{
    Task<List<SearchResult>> SearchAsync(string query);
}