# Add datavalue to datasource

## Value and ValueDate

This is the simplest form of a DataValue. The column `value` and `valueDate` is the minimum requirement  

Request

```http
POST https://connect.digilean.tools/v1/datasources/498/values
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

## Datavalue dimensions

From the previous payload you can see there are more optional columns in a Datavalue object

The more advanced scenario is to insert one or more dimensions. This can be useful for extra information or for filtering of dataValues in DigiLEAN.

The nature of the dimensions are somewhat dynamic. So based on configuration the values to be posted can vary.

### The configuration

The configuration is set up in the DigiLEAN web client and can be fetched by the API by getting the Datasource details:

```http
GET https://connect.digilean.tools/v1/datasources/1348
content-type: application/json
```

Response

```json
{
  "id": 498,
  "title": "1A API documentation",
  "description": "API documentation",
  "objectSource": "external",
  "unitOfTime": "DAY",
  "primaryInputSource": "manual",
  "elements": [
    {
      "id": 707,
      "label": "Plain text",
      "type": "text",
      "isMandatory": true,
      "sourceColumn": "dimension"
    }
  ]
}
```

Inspect the `elements` array of the response of the datasource you are working with. 

The important properties of each configuration element are
 - `sourceColumn` - which column in the dataValue object
 - `type` - what kind of data to enter
 - `isMandatory` - whether the column is required


### The dynamic dimensions

#### Dynamic dimension columns
The following columns can have different data based on the type

 - dimension
 - dimension2
 - dimension3
 - dimension4

### Dynamic dimension types

 - `text` free text up to 100 unicode characters. [Example](#dimension-type-text-example)
 - `number` number with decimals. [Example](#dimension-type-number-example)
 - `bool` true or false. [Example](#dimension-type-bool-example)
 - `list` Id from a DataList item. The config will contain a `dataListId` for this option. [Example](#dimension-type-list-example)
 - `user` UserId of a DigiLEAN user. [Example](#dimension-type-user-example)

### The static dimensions
- type 'description' - column `description`: free text up to 255 characters. [Example](#dimension-type-text-example)
- type 'asset' - column `assetId`: Id of a DigiLEAN group. [Example](#dimension-type-asset-example)
- type 'project' - column `projectId`: Id of a DigiLEAN project [Example](#dimension-type-project-example)

### Other columns

`externalId` is a optional column meant for keeping track when you synchronize from external sources. It can contain up to 100 unicode characters. It's not used for anything in DigiLEAN.


## Dimension type text example

To post a dimension of type `text` or `description` post the plain string to the dimension along with the values and valueDate:

```http
POST https://connect.digilean.tools/v1/datasources/498/values
content-type: application/json
```
```json
{
  "valueDate": "2024-02-25T12:00:00",
  "value": 2,
  "dimension": "short text",
  "description": "long text"
}
```

## Dimension type number example

To post a dimension of type `number` post the number as a string. The supported type is `Double-precision floating-point` and you must use dot as decimal separator.

```http
POST https://connect.digilean.tools/v1/datasources/498/values
content-type: application/json
```
```json
{
  "valueDate": "2024-02-25T12:00:00",
  "value": 1,
  "dimension": "2.5"
}
```

## Dimension type bool example

To post a dimension of type `bool` post `true` or `false` as strings

```http
POST https://connect.digilean.tools/v1/datasources/498/values
content-type: application/json
```
```json
{
  "valueDate": "2024-02-25T12:00:00",
  "value": 1,
  "dimension": "false"
}
```

## Dimension type list example

Type datalist needs to be looked up first.  This is done with the [Datalist items endpoint](/docs/operations/Datalists_Items). 

Type datalist element configuration will have a `dataListId`

```json
{
  "type": "list",
  "isMandatory": true,
  "sourceColumn": "dimension4",
  "dataListId": 61
}
```

Use dataListId to fetch the DataList *items* and then match the item you want to insert.  

```http
GET https://connect.digilean.tools/v1/Datalists/61/items 
Content-Type: application/json
```

Response 

```json
[
  {
    "id": 1208,
    "identifier": "success",
    "name": "Success"
  },
  {
    "id": 1209,
    "identifier": "failure",
    "name": "Failure"
  }
]
```

If the value from the source to insert is "success" then id `1208` must be inserted as the dimension value as a string

```http
POST https://connect.digilean.tools/v1/datasources/498/values
content-type: application/json
```
```json
{
  "valueDate": "2024-02-25T12:00:00",
  "value": 1,
  "dimension": "1208"
}
```
::: tip
If the value is not present it can be [inserted to the Datalist](/docs/operations/Datalists_CreateItem)
:::

## Dimension type asset example

Type asset needs to be looked up first. This is done with the [group endpoint](/docs/operations/Groups_List)


```http
GET https://connect.digilean.tools/v1/Groups
?$filter=name eq 'mygroup' 
Content-Type: application/json
```
```json
{
  "id": 3996,
  "name": "DigiLEAN ",
  "type": "GENERAL",
  "description": "DigiLEAN Test"
}
```

Then insert the Id of the group as a integer into the `assetId` column

```http
POST https://connect.digilean.tools/v1/datasources/498/values
content-type: application/json
```
```json
{
  "valueDate": "2024-02-25T12:00:00",
  "value": 1,
  "assetId": 3996
}
```

## Dimension type project example

Type project needs to be looked up first. This is done with the [project endpoint](/docs/operations/Projects_List)


```http
GET https://connect.digilean.tools/v1/Projects
?$filter=projectNumber eq '007' 
Content-Type: application/json
```
```json
{
  "id": 369,
  "projectNumber": "007",
  "status": "INPROGRESS",
  "name": "DigiLEAN test",
  "customerNumber": "",
  "createdDate": "2019-02-13T13:07:18.4791067Z"
}
```

Then insert the Id of the project as a integer into the `projectId` column

```http
POST https://connect.digilean.tools/v1/datasources/498/values
content-type: application/json
```
```json
{
  "valueDate": "2024-02-25T12:00:00",
  "value": 1,
  "projectId": 369
}
```

## Dimension type user example

Type user needs to be looked up first. This is done with the [user endpoint](/docs/operations/Users_List)

```http
GET https://connect.digilean.tools/v1/Users
?$filter=userName eq 'user@digilean.com' 
Content-Type: application/json
```

```json
[
  {
    "id": "3cfb0ad7-b98e-4032-9f27-1e4f894a655f",
    "roles": [],
    "userName": "user@digilean.com",
    "email": "user@digilean.com",
    "firstName": "DigiLEAN",
    "lastName": "User",
    "fullName": "DigiLEAN User",
    "screenName": "user",
    "businessUnitId": 1
  },
]
```

Then insert the Id of the user as a string into the dimension column

```http
POST https://connect.digilean.tools/v1/datasources/498/values
content-type: application/json
```
```json
{
  "valueDate": "2024-02-25T12:00:00",
  "value": 1,
  "dimension": "3cfb0ad7-b98e-4032-9f27-1e4f894a655f"
}
```