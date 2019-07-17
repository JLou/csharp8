# Nullable reference types

## Configuration

Edit the .csproj and add the following line : 
```xml
<NullableContextOptions>enable</NullableContextOptions>
```

The complete .csproj should look like this : 

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.0</TargetFramework>
    <LangVersion>8.0</LangVersion>
    <NullableContextOptions>enable</NullableContextOptions>
  </PropertyGroup>

</Project>
```

## Sample

### Given the following class
```cs --project ./Snippets/Snippets.csproj --source-file ./Snippets/nullable.cs --region car-class
```

### And the following program

```cs --project ./Snippets/Snippets.csproj --source-file ./Snippets/nullable.cs --region nullable
```

Let's jump into VS 2019 and take a look at the warnings