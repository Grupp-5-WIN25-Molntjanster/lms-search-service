using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;
using SearchService.Core.DTOs;


namespace SearchService.Core.Services;

public class FaqSearchService(HttpClient httpClient, IMemoryCache cache) : ISearchService
{
    public async Task<IEnumerable<SearchResult>> SearchAsync(string query, CancellationToken ct = default)
    {
        var q = query?.Trim().ToLowerInvariant();
        if (string.IsNullOrEmpty(q))
            return [];

        // search the faqs for the query
        var faqs = await GetFaqsAsync(ct);

        return faqs
            .Where(f => f.Title.Contains(q) ||
                        f.Summary.Contains(q) ||
                        f.Content.Contains(q))
            .Select(f => new SearchResult(
                Id: $"faq-{f.Id}",
                Title: f.Title,
                Excerpt: f.Summary,
                Type: "faq",
                Url: $"/help#faq-{f.Id}"
            ))
            .Take(10);
    }

    // get the faqs from faq api
    private async Task<List<FaqApiResponse>> GetFaqsAsync(CancellationToken ct)
    {
        return await cache.GetOrCreateAsync("faqs", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30);
            return await httpClient.GetFromJsonAsync<List<FaqApiResponse>>("/api/faqs", ct) ?? [];
        }) ?? [];
    }
}