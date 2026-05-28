using System;
using System.Collections.Generic;
using System.Text;
using SearchService.Core.DTOs;

namespace SearchService.Core.Services;

public interface ISearchService
{
    Task<IEnumerable<SearchResult>> SearchAsync(string query, CancellationToken ct = default);
}