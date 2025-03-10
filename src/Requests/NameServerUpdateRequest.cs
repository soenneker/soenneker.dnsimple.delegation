using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Delegation.Requests;

/// <summary>
/// Request model for updating domain name servers.
/// </summary>
public record NameServerUpdateRequest
{
    /// <summary>
    /// A list of new name servers for the domain.
    /// </summary>
    [JsonPropertyName("data")]
    public List<string> NameServers { get; set; }
}