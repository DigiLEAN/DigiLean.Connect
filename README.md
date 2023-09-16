# DigiLEAN Connect API

Example code for consuming our API.

[DigiLEAN Connect OpenAPI documentation](https://connect.digilean.tools/swagger/index.html) to get a complete overview of endpoints and methods  
[DigiLEAN Authentication Discovery Document](https://auth.digilean.tools/.well-known/openid-configuration)

[![License](https://img.shields.io/badge/License-BSD_3--Clause-blue.svg)](https://opensource.org/licenses/BSD-3-Clause)

The intention of this code base is to give consumers a starter for their custom integration with DigiLEAN.  
Therefore we allow copying and modyfing codebase according to the [LICENSE](LICENSE)

*We do not necessarily include example code for all endpoints in this repository*  
*We do include an example of how to authenticate with the API using [OAuth 2.0 Client Credentials Grant](https://datatracker.ietf.org/doc/html/rfc6749#section-4.4)*

## dotnet

Open `DigiLEAN.Connect.sln` in Visual Studio. Open `DigiLean.Connect.ConsoleApp` project and edit the appsettings.json with your client credentials and try run the program to test.

## nodejs

Run `test.ts` file by typing `npm test` in the command line