# DigiLEAN Connect

NodeJs package for interacting with our API [DigiLEAN Connect](https://connect.digilean.tools/swagger/index.html)

## Usage
```js
import { DigiLeanConnectClient } from "@digilean/connect"
import type { DataValuesPaged } from "@digilean/connect/lib/types/index.js"

const client = new DigiLeanConnectClient("clientId", "secret")
async function test() {
    const values: DataValuesPaged = await client.v1.dataValues.getAllByDatasourceId(432)
    console.log(values)
}

test().catch(err => console.error(err))
```