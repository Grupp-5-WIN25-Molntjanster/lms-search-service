using System;
using System.Collections.Generic;
using System.Text;

namespace SearchService.Core.DTOs;

public record SearchResult(
    string Id,
    string Title,
    string Excerpt,
    string Type,
    string Url
);
