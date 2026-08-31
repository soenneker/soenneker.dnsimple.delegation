[![](https://img.shields.io/nuget/v/soenneker.dnsimple.delegation.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dnsimple.delegation/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dnsimple.delegation/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.dnsimple.delegation/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.dnsimple.delegation.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.dnsimple.delegation/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.dnsimple.delegation/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.dnsimple.delegation/actions/workflows/codeql.yml)

# Soenneker.DNSimple.Delegation

Lists and changes a DNSimple domain's delegated name servers, including vanity name-server delegation.

## Installation

```bash
dotnet add package Soenneker.DNSimple.Delegation
```

## Configuration and registration

```json
{
  "DNSimple": {
    "AccountId": 12345,
    "Token": "your-api-token",
    "Test": false
  }
}
```

```csharp
using Soenneker.DNSimple.Delegation.Registrars;

services.AddDNSimpleDelegationUtilAsScoped();
```

## Usage

```csharp
public sealed class DelegationService(IDNSimpleDelegationUtil delegation)
{
    public ValueTask<List<string>?> PointTo(
        string domain,
        List<string> nameServers,
        CancellationToken cancellationToken)
    {
        return delegation.ChangeNameServers(domain, nameServers, cancellationToken);
    }
}
```

`ChangeNameServers` replaces the domain's name-server set. `DelegateToVanityNameServers` assigns vanity servers, and `DedelegateFromVanityNameServers` removes that vanity delegation. All operations use the configured `DNSimple:AccountId`; `domain` may be the domain name or DNSimple domain ID accepted by the API.
