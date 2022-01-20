# Duende.IdentityServer.Contrib.AspNetCore.Testing

[![Build Status](https://travis-ci.com/alsami/Duende.IdentityServer.Contrib.AspNetCore.Testing.svg?branch=master)](https://travis-ci.com/alsami/Duende.IdentityServer.Contrib.AspNetCore.Testing)
[![codecov](https://codecov.io/gh/alsami/Duende.IdentityServer.Contrib.AspNetCore.Testing/branch/master/graph/badge.svg)](https://codecov.io/gh/alsami/Duende.IdentityServer.Contrib.AspNetCore.Testing)

[![NuGet](https://img.shields.io/nuget/dt/Duende.IdentityServer.Contrib.AspNetCore.Testing.svg)](https://www.nuget.org/packages/Duende.IdentityServer.Contrib.AspNetCore.Testing)
[![NuGet](https://img.shields.io/nuget/vpre/Duende.IdentityServer.Contrib.AspNetCore.Testing.svg)](https://www.nuget.org/packages/Duende.IdentityServer.Contrib.AspNetCore.Testing)

This library serves as a testing framework for [Duende.IdentityServer](http://docs.identityserver.io/en/latest/) using [Microsoft.AspNetCore.Mvc.Testing](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-3.1) and makes it easy to test your web-applications in combination with `Duende.IdentityServer`.

## Usage

This library is supposed to be used within test-projects. Please checkout the [prerequisites](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.2#test-app-prerequisites) described by Microsoft.

Check out the [docs](docs/) for more information about the usage!

## Installation

This package is available via nuget. You can install it using Visual-Studio-Nuget-Browser or by using the dotnet-cli for your test-project.

```unspecified
dotnet add package Duende.IdentityServer.Contrib.AspNetCore.Testing
```

If you want to add a specific version of this package

```unspecified
dotnet add package Duende.IdentityServer.Contrib.AspNetCore.Testing --version 1.0.0
```

For more information please visit the official [dotnet-cli documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-package).