using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.DNSimple.Delegation.Tests;

[Collection("Collection")]
public class DNSimpleDelegationUtilTests : FixturedUnitTest
{
    private readonly IDNSimpleDelegationUtil _util;

    public DNSimpleDelegationUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IDNSimpleDelegationUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
