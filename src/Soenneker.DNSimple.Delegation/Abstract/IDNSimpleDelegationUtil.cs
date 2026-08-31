using Soenneker.DNSimple.OpenApiClient.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IDNSimpleDelegationUtil
{
    /// <summary>
    /// Lists the name servers currently assigned to a domain.
    /// </summary>
    /// <param name="domain">The domain name or DNSimple domain ID.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The assigned name servers, or <see langword="null"/> when DNSimple returns no data.</returns>
    ValueTask<List<string>?> ListNameServers(string domain, CancellationToken cancellationToken = default);

    /// <summary>
    /// Changes the name servers for a domain.
    /// </summary>
    /// <param name="domain">The domain name or DNSimple domain ID.</param>
    /// <param name="nameServers">The complete name-server set to assign.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The assigned name servers, or <see langword="null"/> when DNSimple returns no data.</returns>
    ValueTask<List<string>?> ChangeNameServers(string domain, List<string> nameServers, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delegates a domain to vanity name servers.
    /// </summary>
    /// <param name="domain">The domain name or DNSimple domain ID.</param>
    /// <param name="nameServers">The vanity name servers to assign.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>The resulting vanity name-server records, or <see langword="null"/> when DNSimple returns no data.</returns>
    ValueTask<List<NameServer>?> DelegateToVanityNameServers(string domain, List<string> nameServers, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes vanity name server delegation from a domain.
    /// </summary>
    /// <param name="domain">The domain name or DNSimple domain ID.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns><see langword="true"/> after DNSimple accepts the deletion.</returns>
    ValueTask<bool> DedelegateFromVanityNameServers(string domain, CancellationToken cancellationToken = default);
}
