# alsami.Duende.IdentityServer.AspNetCore.Testing

[![CI](https://github.com/alsami/alsami.Duende.IdentityServer.AspNetCore.Testing/actions/workflows/push.yml/badge.svg?branch=main)](https://github.com/alsami/alsami.Duende.IdentityServer.AspNetCore.Testing/actions/workflows/push.yml)
[![codecov](https://codecov.io/gh/alsami/alsami.Duende.IdentityServer.AspNetCore.Testing/branch/main/graph/badge.svg?token=cQHpUoEnYt)](https://codecov.io/gh/alsami/alsami.Duende.IdentityServer.AspNetCore.Testing)

[![NuGet](https://img.shields.io/nuget/dt/alsami.Duende.IdentityServer.AspNetCore.Testing.svg)](https://www.nuget.org/packages/alsami.Duende.IdentityServer.AspNetCore.Testing)
[![NuGet](https://img.shields.io/nuget/vpre/alsami.Duende.IdentityServer.AspNetCore.Testing.svg)](https://www.nuget.org/packages/alsami.Duende.IdentityServer.AspNetCore.Testing)

This library serves as a testing framework for [Duende.IdentityServer](https://duendesoftware.com/products/identityserver) using [Microsoft.AspNetCore.TestHost](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests) and makes it easy to test your web-applications in combination with `Duende.IdentityServer`.

## Usage

This library is supposed to be used within test-projects. Please checkout the [prerequisites](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-6.0#test-app-prerequisites) described by Microsoft.

Check out the [docs](docs/) for more information about the usage!

## Installation

This package is available via nuget. You can install it using Visual-Studio-Nuget-Browser or by using the dotnet-cli for your test-project.

```unspecified
dotnet add package alsami.Duende.IdentityServer.AspNetCore.Testing
```

If you want to add a specific version of this package

```unspecified
dotnet add package alsami.Duende.IdentityServer.AspNetCore.Testing --version 1.0.0
```

For more information please visit the official [dotnet-cli documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package).