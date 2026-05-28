using Microsoft.Extensions.Options;
using SearchService.Api.Endpoints;
using SearchService.Api.Options;
using SearchService.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Cache + HTTP
builder.Services.AddMemoryCache();

builder.Services.Configure<FaqApiOptions>(

builder.Configuration.GetSection(FaqApiOptions.SectionName));

builder.Services.AddHttpClient<ISearchService, FaqSearchService>(
    (sp, client) =>
    {
        var options = sp.GetRequiredService<IOptions<FaqApiOptions>>().Value;
        client.BaseAddress = new Uri(options.BaseUrl);
        if (!string.IsNullOrEmpty(options.Token))
            client.DefaultRequestHeaders.Authorization = new("Bearer", options.Token);
    });

// CORS
builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
    p.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    ));

var app = builder.Build();

app.UseCors();
app.MapSearchEndpoints();
app.Run();