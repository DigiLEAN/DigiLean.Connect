# DigiLEAN Connect API

Example code for consuming our API.

If you are looking for the DigiLEAN main product [contact us here](https://www.digilean.com/)

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
Then open `DigiLean.Api.Client.TestConsoleApp` and edit appsettings.json, or create appsettings.Development.json with your client credentials.  
Then try run.

## nodejs

Build first with `npm run build`  
Then create `.env.test` file bases on `.env`with your client credentials.  
Then run `test.ts` file with `npm test`

This client is also packages as a [NPM package](https://www.npmjs.com/package/@digilean/connect)

## Authentication

```http
POST https://auth.digilean.tools/connect/token'
?client_id={your-id}
&client_secret={your-secret}
&grant_type=client_credentials
Content-Type: application/x-www-form-urlencoded
```

## Power Platform

The folder `power.platform` contains the definition for creating a [custom connector for Microsoft Power Platform](https://learn.microsoft.com/en-us/connectors/custom-connectors/) 

We will try to publish this connector but in the meantime it can be created using these files.

[How to package Connector for publish](https://learn.microsoft.com/en-us/connectors/custom-connectors/certification-submission#package-your-custom-connector-and-submit-for-certification)