Owner: Albin Nilsson

### API for searching across the platform.

### Features
- Search FAQs by query string (matches title, summary, content)
- Easy to build out functionallity to search other pages (but only uses faq-service api as for now)
- In-memory caching
- Top 10 results with link

### Tech Stack
- C#
- .NET 10.0
- ASP.NET Core Minimal API
- IHttpClientFactory
- IMemoryCache
- Scalar + OpenApi

### API Endpoints
| Method | Route                      | Description                 |
| ------ | -------------------------- | --------------------------- |
| GET    | `/api/search?query=string` | Search across other content |

For more information visit /docs to see scalar documentation.

### How to run
#### Requirements
- .NET 10.0 SDK

#### Run locally
- cd (your repo clone location)/lms-search-service/src/SearchService.Api
- dotnet restore
- dotnet run
  
Open http://localhost:5175/docs to view the scalar documentation.

### Azure Deployment
The service is deployed to Azure.
URL: http://lms-search-service.azurewebsites.net
Scalar: http://lms-search-service.azurewebsites.net/docs

### Frontend
This service also have frontend build for it and can be found in the lms-frontend repo. The search dropdown component is at src/components/search/SearchDropdown.tsx and the API call is in src/lib/search.ts. Use the NEXT_PUBLIC_SEARCH_API_URL variable to connect it to either the localhost or Azure url.
