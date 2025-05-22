using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.DNSimple.OpenApiClient;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Delegation;
using Soenneker.DNSimple.OpenApiClient.Item.Registrar.Domains.Item.Delegation.Vanity;
using Soenneker.DNSimple.OpenApiClient.Models;
using Soenneker.DNSimple.OpenApiClientUtil.Abstract;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.Task;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Extensions.ValueTask;

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
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        DelegationGetResponse? response = await client[_accountId].Registrar.Domains[domain].Delegation.GetAsDelegationGetResponseAsync(cancellationToken: cancellationToken).NoSync();
        return response?.Data;
    }

    public async ValueTask<List<string>?> ChangeNameServers(string domain, List<string> nameServers, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        DelegationPutResponse? response = await client[_accountId]
                                                .Registrar.Domains[domain]
                                                .Delegation.PutAsDelegationPutResponseAsync(nameServers, cancellationToken: cancellationToken).NoSync();
        return response?.Data;
    }

    public async ValueTask<List<NameServer>?> DelegateToVanityNameServers(string domain, List<string> nameServers,
        CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        VanityPutResponse? response = await client[_accountId]
                                            .Registrar.Domains[domain]
                                            .Delegation.Vanity.PutAsVanityPutResponseAsync(nameServers, cancellationToken: cancellationToken).NoSync();
        return response?.Data;
    }

    public async ValueTask<bool> DedelegateFromVanityNameServers(string domain, CancellationToken cancellationToken = default)
    {
        DNSimpleOpenApiClient client = await _clientUtil.Get(cancellationToken).NoSync();
        await client[_accountId].Registrar.Domains[domain].Delegation.Vanity.DeleteAsync(cancellationToken: cancellationToken).NoSync();
        return true;
    }
}