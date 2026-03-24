using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Bandwidth.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class BandwidthOpenApiClientTests : FixturedUnitTest
{
    public BandwidthOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
