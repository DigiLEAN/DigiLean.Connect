# Enable Sharepoint Site access for DigiLEAN Connect

To integrate DigiLEAN Connect with data in Sharepoint we need access to read content in your Sharepoint site

This document explains how to give DigiLEAN Connect access to read a specific Sharepoint Site where you have Excel files, Lists etc
that you want to read into DigiLEAN

## Two steps

 1. Grant permission to the “DigiLEAN Connect Sharepoint Site” App registration in Entra ID
 2. Grant access to specific site(s) for App registration with Graph Explorer 

::: info
`https://leanhub.sharepoint.com/sites/Excellence` is used as an example in this document. Replace with your own site url.
:::


## Grant permission to App registration

This step is to register the “DigiLEAN  Connect Sharepoint Site” app to your Entra Id 

 1. Go to [DigiLEAN Enterprise Applications](/enterprise/)
 2. Click “Connect Sharepoint Selected Site” button
 3. A popup should appear. Follow the steps to add the app to your tenant’s Enterprise Applications. Click “Accept”

![Sharepoint site consent](/images/Sharepoint_site_consent.jpg)  

 4. Login to https://portal.azure.com
 5. Go to Microsoft Entra Id => “Enterprise Applications”
 6. Find and Click on the “DigiLEAN Connect Sharepoint Site”
 7. Go to Permission and “Grant admin consent” to the app. (This will not give access to any site, just open the ability to do so.)
 8. Click “Refresh” and make sure the Permissions are now enabled for “Sites.Selected”

![Sharepoint site admin consent](/images/Sharepoint_site_admin_grant_consent.jpg)

## Grant permission to Site with Graph Explorer

 1. Go to [Microsoft Graph Explorer](https://developer.microsoft.com/en-us/graph/graph-explorer) and log in as a Sharepoint Administrator 

 2. Use the `Get site by path` method to find the Sharepoint site id. The site id is needed in the next step to grant read permission to the Sharepoint site for the “DigiLEAN  Connect Sharepoint Site” app.  

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

3. Use the `Create permissions` method to grant “read” permission to the site for the "DigiLEAN Connect Sharepoint Site" app. 


```http
POST https://graph.microsoft.com/v1.0/sites/leanhub.sharepoint.com,91ba15c7-3398-4798-8dfd-56b8c124552a,7f96db8a-2214-4271-8b3c-1e91413d5267/permissions
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

::: info
Note that as a minimum the “Sites.FullControl.All” permission is required for the user to be able to grant permissions in Graph Explorer. See below how to this

[Complete Microsoft Graph REST API v1.0 endpoint documentation for reference](https://learn.microsoft.com/en-us/graph/api/overview?view=graph-rest-1.0&preserve-view=true)
:::

## Consent to permissions in Graph Explorer

If needed, consent to the Sites.FullControl.All permission to Graph Explorer.

 1.	Click on the user in the top right corner in Graph Explorer. 
![Graph Explorer Consent step 1](/images/Sharepoint_site_graph_explorer_consent1.jpg)

 2.	Click “Consent to permissions”
![Graph Explorer Consent step 1](/images/Sharepoint_site_graph_explorer_consent2.jpg)

 3. Search for “sites” and click “Consent” on the permission “Sites.FullControl.All”.
![Graph Explorer Consent step 1](/images/Sharepoint_site_graph_explorer_consent3.jpg)

 4. Click “Accept”
![Graph Explorer Consent step 1](/images/Sharepoint_site_graph_explorer_consent4.jpg)

 5. The button should now have the label “Unconsent” and the user should be allowed to grant permissions for a site.
![Graph Explorer Consent step 1](/images/Sharepoint_site_graph_explorer_consent5.jpg)