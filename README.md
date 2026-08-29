[![](https://img.shields.io/nuget/v/soenneker.extensions.parameterinfo.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.parameterinfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.parameterinfo/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.parameterinfo/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.parameterinfo.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.parameterinfo/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.parameterinfo/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.parameterinfo/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.ParameterInfo
Projects reflected method parameters to their declared CLR types.

## Installation

```bash
dotnet add package Soenneker.Extensions.ParameterInfo
```

## Usage

```csharp
using Soenneker.Extensions.ParameterInfo;

MethodInfo method = typeof(string).GetMethod(nameof(string.StartsWith), [typeof(string)])!;
Type[] parameterTypes = method.GetParameters().ToTypes();
// [typeof(string)]
```

`ToTypes()` preserves parameter order and returns a newly allocated array containing each `ParameterType`. An empty parameter array produces an empty type array. The source array and its elements must be non-null.
