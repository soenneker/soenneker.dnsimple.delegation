using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Delegation.Responses;

/// <summary>
/// Response model for listing domain name servers.
/// </summary>
public record NameServerListResponse
{
    /// <summary>
    /// The list of name servers assigned to the domain.
    /// </summary>
    [JsonPropertyName("data")]
    public List<string> NameServers { get; set; }
}