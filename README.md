[![](https://img.shields.io/nuget/v/soenneker.bandwidth.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bandwidth.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bandwidth.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.bandwidth.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.bandwidth.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.bandwidth.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.bandwidth.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.bandwidth.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Bandwidth.OpenApiClient

A Kiota-generated .NET client containing request builders and models for Bandwidth APIs.

## Installation

```bash
dotnet add package Soenneker.Bandwidth.OpenApiClient
```

## Creating a client

The generated client accepts a Kiota `IRequestAdapter`. This Basic-auth example is suitable for a Bandwidth service that uses username/password credentials:

```csharp
using System.Net.Http.Headers;
using System.Text;
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Bandwidth.OpenApiClient;

string credential = Convert.ToBase64String(
    Encoding.UTF8.GetBytes($"{username}:{password}"));

httpClient.BaseAddress = new Uri("https://api.bandwidth.com/api/v2/");
httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Basic", credential);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient);

var client = new BandwidthOpenApiClient(adapter);
```

For dependency-injection setup with one configurable authentication header, use [`Soenneker.Bandwidth.OpenApiClientUtil`](https://www.nuget.org/packages/Soenneker.Bandwidth.OpenApiClientUtil).

## Usage

Request builders follow each service's path hierarchy. For example, listing messages for a messaging user is exposed under `Messaging.Users`:

```csharp
using Soenneker.Bandwidth.OpenApiClient.Models;

MessagesList? messages = await client
    .Messaging
    .Users[userId]
    .Messages
    .GetAsync(cancellationToken: cancellationToken);
```

## Important behavior

- This package combines many Bandwidth API specifications, including messaging, voice, number management, emergency services, authentication, and account services.
- Those services do not all share one base URL or authentication scheme. Configure a separate adapter/client for each host and credential set you use.
- Some endpoints require Basic authentication, some accept bearer tokens, and others require additional headers. Follow the requirements of the specific Bandwidth API rather than assuming the generated client's default applies everywhere.
- Request and response types are in `Soenneker.Bandwidth.OpenApiClient.Models`.
- Kiota surfaces mapped non-success responses through generated error models and `ApiException` behavior.
- The source is generated. Configure authentication, retries, and logging in the adapter or HTTP pipeline instead of editing generated files.
