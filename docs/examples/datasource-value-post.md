# Add datavalue to datasource

Request

```http
POST https://connect.digilean.tools/v1/datasources/1348/values
content-type: application/json
```
```json
{
    "valueDate": "2024-02-25T12:00:00",
    "value": 2
}
```

Response

```http
content-type: application/json; charset=utf-8
location: /v1/datasources/1348/values/291411700
```

```json
{
  "id": 291411700,
  "dataSourceId": 1348,
  "registrationDate": "2024-10-14T12:26:15.8816103Z",
  "areaId": null,
  "assetId": null,
  "projectId": null,
  "value": 2,
  "description": null,
  "dimension": null,
  "dimension2": null,
  "dimension3": null,
  "dimension4": null,
  "valueDate": "2024-02-25T12:00:00Z",
  "externalId": null
}
```