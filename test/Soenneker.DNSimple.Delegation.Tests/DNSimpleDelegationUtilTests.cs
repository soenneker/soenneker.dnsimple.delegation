using Soenneker.Tests.HostedUnit;

namespace Soenneker.DNSimple.Delegation.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class DNSimpleDelegationUtilTests : HostedUnitTest
{
    private readonly IDNSimpleDelegationUtil _util;

    public DNSimpleDelegationUtilTests(Host host) : base(host)
    {
        _util = Resolve<IDNSimpleDelegationUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
