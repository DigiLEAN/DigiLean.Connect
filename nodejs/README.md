# DigiLEAN Connect

NodeJs package for interacting with our API [DigiLEAN Connect](https://connect.digilean.tools/swagger/index.html)

## Usage
```js
import { DigiLeanConnectClient } from "@digilean/connect"
import type { DataValuesPaged } from "@digilean/connect/lib/types/index.js"

const client = new DigiLeanConnectClient("clientId", "secret")
async function testDigiLeanConnect() {

    const dataSourceId = 432

    // list values in datasource
    const values: DataValuesPaged = await client.v1.dataValues.getAllByDatasourceId(datasourceId)
    console.log("list all values", values)

    // write new datavalue
    const newValue: DataValueCreate = {
        dataSourceId,
        value: 123,
        valueDate: new Date().toISOString()
    }
    const res = await client.v1.dataValues.writeValue(dataSourceId, newValue)
    console.log("new value created", res)

    //delete value
    const dataValueId = 4754300
    await client.v1.dataValues.deleteValue(dataSourceId, dataValueId)
}



test().catch(err => console.error(err))
```