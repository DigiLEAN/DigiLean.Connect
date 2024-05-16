# DigiLEAN Connect API

Example code for consuming our API.

## Docs

- [DigiLEAN Connect Full OpenAPI documentation](https://connect.digilean.tools/swagger/index.html)  
- [DigiLEAN Authentication Discovery Document](https://auth.digilean.tools/.well-known/openid-configuration)


[![License](https://img.shields.io/badge/License-BSD_3--Clause-blue.svg)](https://opensource.org/licenses/BSD-3-Clause)

The intention of this code base is to give an example or a starter for their integration with DigiLEAN.  
Copying and modyfing this code is allowed according to the [LICENSE](LICENSE)

*We do not necessarily include example code for all endpoints in this repository*  
*We do include an example of how to authenticate with the API using [OAuth 2.0 Client Credentials Grant](https://datatracker.ietf.org/doc/html/rfc6749#section-4.4)*

## dotnet

Open `DigiLEAN.Connect.sln` in Visual Studio.  

Then see `DigiLean.Api.Client.TestConsoleApp` project and edit the appsettings.json with your client credentials and try run the program to test.

## nodejs

Build first with `npm run build`  
Then run `test.ts` file with `npm test`

This client is also packages as a [NPM package](https://www.npmjs.com/package/@digilean/connect)