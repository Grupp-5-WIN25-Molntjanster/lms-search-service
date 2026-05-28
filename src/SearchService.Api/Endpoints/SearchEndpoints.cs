using Microsoft.Extensions.Options;
using SearchService.Api.Options;
using SearchService.Core.DTOs;
using SearchService.Core.Services;
namespace SearchService.Api.Endpoints;

public static class SearchEndpoints
{
    public static void MapSearchEndpoints(this WebApplication app)
    {
        // GET /api/search?query=example

        app.MapGet("/api/search", async (
            string? query,
            ISearchService searchService,
            CancellationToken ct) =>
        {
            var results = await searchService.SearchAsync(query ?? "", ct);
            return Results.Ok(results);
        })
        .WithName("Search");
    }
}
