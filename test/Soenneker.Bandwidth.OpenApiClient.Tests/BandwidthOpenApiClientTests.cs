using Soenneker.Tests.HostedUnit;

namespace Soenneker.Bandwidth.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class BandwidthOpenApiClientTests : HostedUnitTest
{
    public BandwidthOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
