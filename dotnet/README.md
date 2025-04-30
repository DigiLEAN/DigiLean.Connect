# DigiLEAN Connect API Client

## Build nuget

Model
```sh
cd DigiLean.Api.Model
dotnet pack DigiLean.Api.Model.csproj -o nugetPackage

cd nugetPackage

dotnet nuget push DigiLean.Api.Model.4.10.2.nupkg --api-key xxx --source https://api.nuget.org/v3/index.json
```

Api Client
```sh
cd DigiLean.Api.Client
dotnet pack -o nugetPackage

cd nugetPackage

dotnet nuget push DigiLean.Api.Client.4.10.2.nupkg --api-key xxx --source https://api.nuget.org/v3/index.json
```