using ConsolidatedSearchAPI.Models;
using ConsolidatedSearchAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddTransient<ISearchService, TvMazeService>();
builder.Services.AddTransient<ISearchService, ITunesService>();
builder.Services.AddTransient<ISearchService, CRCINDService>();

// Register the dictionary for the strategy pattern
builder.Services.AddSingleton<IDictionary<SourceType, ISearchService>>(provider =>
{
    // Get all registered IRebateCalculator implementations
    var calculators = provider.GetServices<ISearchService>();

    return new Dictionary<SourceType, ISearchService>
    {
                { SourceType.TvMaze, calculators.OfType<TvMazeService>().First() },
                { SourceType.ITunes, calculators.OfType<ITunesService>().First() },
                { SourceType.CRCIND, calculators.OfType<CRCINDService>().First() }
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Consolidated Search API v1"));


app.Run();
