using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.DNSimple.Client.Abstract;
using Soenneker.DNSimple.Delegation.Abstract;
using Soenneker.DNSimple.Delegation.Requests;
using Soenneker.DNSimple.Delegation.Responses;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.HttpClient;
using Soenneker.Extensions.ValueTask;

namespace Soenneker.DNSimple.Delegation;

/// <inheritdoc cref="IDNSimpleDelegationUtil"/>
public class DNSimpleDelegationUtil: IDNSimpleDelegationUtil
{
    private readonly IDNSimpleClientUtil _clientUtil;
    private readonly ILogger<DNSimpleDelegationUtil> _logger;
    private readonly string _accountId;

    public DNSimpleDelegationUtil(IDNSimpleClientUtil clientUtil, IConfiguration configuration, ILogger<DNSimpleDelegationUtil> logger)
    {
        _clientUtil = clientUtil;
        _logger = logger;
        _accountId = configuration.GetValueStrict<string>("DNSimple:AccountId");
    }

    /// <summary>
    /// Lists all name servers for a domain.
    /// </summary>
    public async ValueTask<NameServerListResponse?> ListNameServers(string domain, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/delegation";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<NameServerListResponse>(HttpMethod.Get, endpoint, null, _logger, cancellationToken);
    }

    /// <summary>
    /// Changes the name servers for a domain.
    /// </summary>
    public async ValueTask<NameServerListResponse?> ChangeNameServers(string domain, NameServerUpdateRequest request, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/delegation";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<NameServerListResponse>(HttpMethod.Put, endpoint, request, _logger, cancellationToken);
    }

    /// <summary>
    /// Delegates a domain to vanity name servers.
    /// </summary>
    public async ValueTask<VanityNameServerResponse?> DelegateToVanityNameServers(string domain, NameServerUpdateRequest request, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/delegation/vanity";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return await client.SendToType<VanityNameServerResponse>(HttpMethod.Put, endpoint, request, _logger, cancellationToken);
    }

    /// <summary>
    /// Removes vanity name server delegation from a domain.
    /// </summary>
    public async ValueTask<bool> DedelegateFromVanityNameServers(string domain, bool test = false, CancellationToken cancellationToken = default)
    {
        var endpoint = $"{_accountId}/registrar/domains/{domain}/delegation/vanity";
        HttpClient client = await _clientUtil.Get(test, cancellationToken).NoSync();
        return (await client.SendToType<VanityNameServerResponse>(HttpMethod.Delete, endpoint, null, _logger, cancellationToken)) != null;
    }
}
