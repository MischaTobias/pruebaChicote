using ConsolidatedSearchAPI.Models;
using ConsolidatedSearchAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsolidatedSearchAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SearchController(IDictionary<SourceType, ISearchService> searchServices) : ControllerBase
{
    private readonly ISearchService _tvMazeService = searchServices[SourceType.TvMaze];
    private readonly ISearchService _iTunesService = searchServices[SourceType.ITunes];
    private readonly ISearchService _crcindService = searchServices[SourceType.CRCIND];

    [HttpGet]
    public async Task<IActionResult> Search(string query, int page = 1, int pageSize = 10)
    {
        if (page <= 0 || pageSize <= 0)
        {
            return BadRequest("Page and page size must be greater than 0.");
        }

        var tvResults = await _tvMazeService.SearchAsync(query);
        var itunesResults = await _iTunesService.SearchAsync(query);
        var crcindResults = await _crcindService.SearchAsync(query);

        var consolidatedResults = tvResults.Concat(itunesResults).Concat(crcindResults)
            .OrderBy(r => r.Title)
            .ToList();

        var paginatedResults = consolidatedResults
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        var totalResults = consolidatedResults.Count;

        var response = new
        {
            TotalResults = totalResults,
            Page = page,
            PageSize = pageSize,
            TotalPages = (int)Math.Ceiling(totalResults / (double)pageSize),
            Results = paginatedResults
        };

        return Ok(response);
    }

}