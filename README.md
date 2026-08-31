[![](https://img.shields.io/nuget/v/soenneker.fastly.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.fastly.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.fastly.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.fastly.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.fastly.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.fastly.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.fastly.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.fastly.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Fastly.OpenApiClientUtil

Provides lazy, cached access to the generated Fastly API client.

## Installation

```bash
dotnet add package Soenneker.Fastly.OpenApiClientUtil
```

## Configure and register

```json
{
  "Fastly": {
    "ApiKey": "your-api-token"
  }
}
```

```csharp
using Soenneker.Fastly.OpenApiClientUtil.Registrars;

services.AddFastlyOpenApiClientUtilAsScoped();
```

## Use the client

```csharp
using Soenneker.Fastly.OpenApiClientUtil.Abstract;

public sealed class CurrentUserReader(IFastlyOpenApiClientUtil clients)
{
    public async Task Read(CancellationToken cancellationToken)
    {
        var client = await clients.Get(cancellationToken);
        var currentUser = await client.Current_user.GetAsync(
            cancellationToken: cancellationToken);
    }
}
```

The first call to `Get()` creates the generated client; later calls on the same utility instance return it from the cache. The HTTP provider applies the `Fastly-Key` header, so the generated client does not add a second authentication header.

Use `AddFastlyOpenApiClientUtilAsSingleton()` when the application should share one generated client. A scoped utility borrows the singleton HTTP provider; disposing the scope releases the utility without destroying the shared transport.
