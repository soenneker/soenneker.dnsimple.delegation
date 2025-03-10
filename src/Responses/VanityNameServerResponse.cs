using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Delegation.Responses;

/// <summary>
/// Response model for delegating to vanity name servers.
/// </summary>
public record VanityNameServerResponse
{
    /// <summary>
    /// The list of vanity name servers assigned to the domain.
    /// </summary>
    [JsonPropertyName("data")]
    public List<VanityNameServerData> NameServers { get; set; }
}