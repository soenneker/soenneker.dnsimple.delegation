using System;
using System.Text.Json.Serialization;

namespace Soenneker.DNSimple.Delegation.Responses;

/// <summary>
/// Represents a vanity name server.
/// </summary>
public record VanityNameServerData
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("ipv4")]
    public string Ipv4 { get; set; }

    [JsonPropertyName("ipv6")]
    public string Ipv6 { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}