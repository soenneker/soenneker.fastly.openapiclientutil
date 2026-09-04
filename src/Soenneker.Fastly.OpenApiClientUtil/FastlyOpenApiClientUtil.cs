using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Fastly.HttpClients.Abstract;
using Soenneker.Fastly.OpenApiClientUtil.Abstract;
using Soenneker.Fastly.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Fastly.OpenApiClientUtil;

/// <inheritdoc cref="IFastlyOpenApiClientUtil" />
public sealed class FastlyOpenApiClientUtil : IFastlyOpenApiClientUtil
{
    private readonly AsyncSingleton<FastlyOpenApiClient> _client;

    public FastlyOpenApiClientUtil(IFastlyOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<FastlyOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var requestAdapter = new HttpClientRequestAdapter(new AnonymousAuthenticationProvider(), httpClient: httpClient);

            return new FastlyOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<FastlyOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
