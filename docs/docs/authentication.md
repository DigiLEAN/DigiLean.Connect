# Authentication

 DigiLEAN Connect API use **Client Credentials** and 
    **Bearer token** for authentication

<p>
    <em>Scopes</em> are used for limiting access to endpoints and operations.
</p>
<p>The lifetime of the access token is default 24 hours
</p>

## Retrieve access token

<p><em>Token request</em></p>

<small>URL-encoded form submission</small>

```http
POST https://auth.digilean.tools/connect/token
Content-Type: application/x-www-form-urlencoded

 client_id={your-id}
 &client_secret={your-secret}
 &grant_type=client_credentials

```

<p>
    <em>Token response</em>
</p>
<p>
    <small>parts of token is omitted</small>
</p>

```json
{
    "access_token": "eyJhbGciOiJFUzM4NCIsImtpZCI6Ijk2YzU0MTQ4Y2U4MTQzMWNh...",
    "expires_in": 86400,
    "token_type": "Bearer",
    "scope": "Data.Read Data.ReadWrite"
}
```

## Use the access token
<p>
    Use <em>access token</em> in authorization header
</p>

```http
GET https://connect.digilean.tools/v1/datasources
Authorization: Bearer eyJhbGciOiJFUzM4NCIsImtpZCI6Ijk2YzU0MTQ4Y2U4MTQzMWNh...

```
