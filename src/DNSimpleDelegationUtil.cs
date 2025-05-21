using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.DNSimple.OpenApiClient;
using Soenneker.DNSimple.OpenApiClient.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Delegation;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Delegation.Vanity;
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.Extensions.Configuration;

public sealed class DNSimpleDelegationUtil : IDNSimpleDelegationUtil
{
    private readonly IDNSimpleOpenApiClientUtil _clientUtil;
    private readonly int _accountId;

    public DNSimpleDelegationUtil(IDNSimpleOpenApiClientUtil clientUtil, IConfiguration configuration, ILogger<DNSimpleDelegationUtil> logger)
    {
        _clientUtil = clientUtil;
        _accountId = configuration.GetValueStrict<int>("DNSimple:AccountId");
    }

    public async ValueTask<List<string>?> ListNameServers(string domain, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        DelegationGetResponse? response = await client[_accountId].Registrar.Domains[domain].Delegation.GetAsDelegationGetResponseAsync(cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<List<string>?> ChangeNameServers(string domain, List<string> nameServers, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        DelegationPutResponse? response = await client[_accountId]
                                                .Registrar.Domains[domain]
                                                .Delegation.PutAsDelegationPutResponseAsync(nameServers, cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<List<NameServer>?> DelegateToVanityNameServers(string domain, List<string> nameServers,
        CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        VanityPutResponse? response = await client[_accountId]
                                            .Registrar.Domains[domain]
                                            .Delegation.Vanity.PutAsVanityPutResponseAsync(nameServers, cancellationToken: cancellationToken);
        return response?.Data;
    }

    public async ValueTask<bool> DedelegateFromVanityNameServers(string domain, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken);
        await client[_accountId].Registrar.Domains[domain].Delegation.Vanity.DeleteAsync(cancellationToken: cancellationToken);
        return true;
    }
}