using Soenneker.DNSimple.OpenApiClient.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IDNSimpleDelegationUtil
{
    /// <summary>
    /// Lists all name servers for a domain.
    /// </summary>
    ValueTask<List<string>?> ListNameServers(string domain, CancellationToken cancellationToken = default);

    /// <summary>
    /// Changes the name servers for a domain.
    /// </summary>
    ValueTask<List<string>?> ChangeNameServers(string domain, List<string> nameServers, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delegates a domain to vanity name servers.
    /// </summary>
    ValueTask<List<NameServer>?> DelegateToVanityNameServers(string domain, List<string> nameServers, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes vanity name server delegation from a domain.
    /// </summary>
    ValueTask<bool> DedelegateFromVanityNameServers(string domain, CancellationToken cancellationToken = default);
}