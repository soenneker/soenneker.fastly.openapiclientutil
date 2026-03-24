using Soenneker.Fastly.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Fastly.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class FastlyOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IFastlyOpenApiClientUtil _openapiclientutil;

    public FastlyOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IFastlyOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
