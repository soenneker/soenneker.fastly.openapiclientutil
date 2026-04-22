using Soenneker.Fastly.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Fastly.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class FastlyOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IFastlyOpenApiClientUtil _openapiclientutil;

    public FastlyOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IFastlyOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
