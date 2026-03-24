using Soenneker.Fastly.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Fastly.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface IFastlyOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<FastlyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
