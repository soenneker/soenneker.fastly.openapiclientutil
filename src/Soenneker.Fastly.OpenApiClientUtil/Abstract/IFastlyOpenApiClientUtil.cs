using Soenneker.Fastly.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Fastly.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides lazy access to a cached Fastly API client.
/// </summary>
public interface IFastlyOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached Fastly API client, creating it on first use.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The generated Fastly API client.</returns>
    ValueTask<FastlyOpenApiClient> Get(CancellationToken cancellationToken = default);
}
