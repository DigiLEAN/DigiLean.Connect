# Get datasources and values

## Get datasource


Request

```http
GET https://connect.digilean.tools/v1/datasources/1348
```


Response

```json
{
  "id": 1348,
  "title": "API test source",
  "description": "Datasource to test API",
  "objectSource": "external",
  "unitOfTime": "DAY",
  "primaryInputSource": "manual",
  "elements": [
    {
      "id": 4195,
      "label": "Booking type",
      "type": "list",
      "isMandatory": false,
      "sourceColumn": "dimension",
      "dataSourceId": 1348,
      "dataListId": 823
    }
  ]
}
```

## Get Datasource values

Request

```http
GET https://connect.digilean.tools/v1/datasources/1348/values
```

Response


```json
{
  "pageSize": 1000,
  "pageNo": 1,
  "count": 3,
  "values": [
    {
      "id": 5390540,
      "dataSourceId": 1348,
      "registrationDate": "2024-10-10T09:57:43.7519455Z",
      "value": 2,
      "description": null,
      "dimension": "11953",
      "valueDate": "2022-02-25T23:00:00Z",
      "externalId": null
    },
    {
      "id": 137792935,
      "dataSourceId": 1348,
      "registrationDate": "2024-10-10T09:57:37.4117097Z",
      "value": 1200,
      "description": null,
      "dimension": "11952",
      "valueDate": "2023-08-22T13:00:00Z",
    },
    {
      "id": 290099573,
      "dataSourceId": 1348,
      "registrationDate": "2024-10-10T10:08:22.2835483Z",
      "value": 1200,
      "description": null,
      "valueDate": "2023-08-22T13:00:00Z",
      "externalId": "123"
    }
  ]
}
```