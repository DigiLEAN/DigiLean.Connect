# Enable Sharepoint Site access for DigiLEAN Connect

## Two steps

 - Grant permission to the “DigiLEAN Connect Sharepoint Site” App registration in Entra ID
 - Grant access to specific site(s) for App registration with Graph Explorer 

::: info
https://leanhub.sharepoint.com/sites/Excellence is used as an example in this document. Replace with your own site url.
:::


## Grant permission to App registration

This step is to register the “DigiLEAN  Connect Sharepoint Site” app to your Entra Id 

 - Go to https://connect.digilean.tools
 - Click “Connect Sharepoint Selected Site” button
 - A popup should appear. Follow the steps to add the app to your tenant’s Enterprise Applications. Click “Accept”
 - Login to https://portal.azure.com
 - Go to Microsoft Entra Id => “Enterprise Applications”
 - Find and Click on the “DigiLEAN Connect Sharepoint Site”
 - Go to Permission and “Grant admin consent” to the app. (This will not give access to any site, just open the ability to do so.)
 - Click “Refresh” and make sure the Permissions are now enabled for “Sites.Selected”


## Grant permission to Site with Graph Explorer

- Go to [Microsoft Graph Explorer](https://developer.microsoft.com/en-us/graph/graph-explorer) and log in as a Sharepoint Administrator 

- Use the Get site by path method to find the Sharepoint site id. The site id is needed in the next step to grant read permission to the Sharepoint site for the “DigiLEAN  Connect Sharepoint Site” app.  

```http
GET https://graph.microsoft.com/v1.0/sites/leanhub.sharepoint.com:/sites/Excellence
```
Response
```json
{
    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#sites/$entity",
    "@microsoft.graph.tips": "Use $select to choose only the properties your app needs, as this can lead to performance improvements. For example: GET sites('<key>')/microsoft.graph.getByPath(path=<key>)?$select=displayName,error",
    "createdDateTime": "2021-11-03T10:58:09.133Z",
    "description": "Excellence",
    "id": "leanhub.sharepoint.com,91ba15c7-3398-4798-8dfd-56b8c124552a,7f96db8a-2214-4271-8b3c-1e91413d5267",
    "lastModifiedDateTime": "2024-12-18T09:52:43Z",
    "name": "Excellence",
    "webUrl": "https://leanhub.sharepoint.com/sites/Excellence",
    "displayName": "Excellence",
    "root": {},
    "siteCollection": {
        "hostname": "leanhub.sharepoint.com"
    }
}
```

- Pick out the `id` and `displayName` values

- Use the Create permissions method to create “read” permission to the site for the DigiLEAN Connector app. 

::: tip 
Use the request body as is from the example below as this is the correct app id for the “DigiLEAN Connect Sharepoint Site” app 
:::

```http
POST https://graph.microsoft.com/v1.0/sites/leanhub.sharepoint.com,91ba15c7-3398-4798-8dfd-56b8c124552a,7f96db8a-2214-4271-8b3c-1e91413d5267/permissions
```
```json
{
    "roles": ["read"],
    "grantedToIdentities": [{
        "application": {
            "id": "01f47464-fcaa-41ea-84a9-26340bebfe40",
            "displayName": "DigiLEAN Connect Sharepoint Site"
        }
    }]
}
```

Response
```json
{
    "@odata.context": "https://graph.microsoft.com/v1.0/$metadata#sites('leanhub.sharepoint.com%2C91ba15c7-3398-4798-8dfd-56b8c124552a%2C7f96db8a-2214-4271-8b3c-1e91413d5267')/permissions/$entity",
    "id": "aTowaS50fG1zLnNwLmV4dHwwMWY0NzQ2NC1mY2FhLTQxZWEtODRhOS0yNjM0MGJlYmZlNDBAYTI4OWJlYTYtM2IwNS00MGMxLWE2ODQtOGY4MTY4M2Y1ZGFh",
    "roles": [
        "read"
    ],
    "grantedToIdentitiesV2": [
        {
            "application": {
                "displayName": "DigiLEAN Connect Sharepoint Site",
                "id": "01f47464-fcaa-41ea-84a9-26340bebfe40"
            }
        }
    ],
    "grantedToIdentities": [
        {
            "application": {
                "displayName": "DigiLEAN Connect Sharepoint Site",
                "id": "01f47464-fcaa-41ea-84a9-26340bebfe40"
            }
        }
    ]
}
```