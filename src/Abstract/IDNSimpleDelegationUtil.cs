using Soenneker.DNSimple.Delegation.Requests;
using Soenneker.DNSimple.Delegation.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.DNSimple.Delegation.Abstract;

/// <summary>
/// A .NET typesafe implementation of DNSimple's Delegation API
/// </summary>
public interface IDNSimpleDelegationUtil
{
    /// <summary>
    /// Lists all name servers for a domain.
    /// </summary>
    ValueTask<NameServerListResponse?> ListNameServers(string domain, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Changes the name servers for a domain.
    /// </summary>
    ValueTask<NameServerListResponse?> ChangeNameServers(string domain, NameServerUpdateRequest request, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delegates a domain to vanity name servers.
    /// </summary>
    ValueTask<VanityNameServerResponse?> DelegateToVanityNameServers(string domain, NameServerUpdateRequest request, bool test = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes vanity name server delegation from a domain.
    /// </summary>
    ValueTask<bool> DedelegateFromVanityNameServers(string domain, bool test = false, CancellationToken cancellationToken = default);
}
