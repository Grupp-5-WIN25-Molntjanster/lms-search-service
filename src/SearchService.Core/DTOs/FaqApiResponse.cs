using System;
using System.Collections.Generic;
using System.Text;

namespace SearchService.Core.DTOs;

public record FaqApiResponse(
    int Id,
    string Title,
    string Summary,
    string Content,
    int DisplayOrder
);
