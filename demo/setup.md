# Setup

## .Net Core 3.0
You need to download and install the .Net Core 3.0 SDK. 

Direct link : [clic](https://dotnet.microsoft.com/download/dotnet-core/3.0)

## Run C# 8 app

1. Create a new dotnet core console app for example.
2. Open the .csproj
3. Add the following lines. Your .csproj should look like this : 

```cs
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <LangVersion>8.0</LangVersion>
  </PropertyGroup>

</Project>
```

#### Next: [Pattern matching  &raquo;](./PATTERN-MATCHING.md)   Home: [Home](readme.md)